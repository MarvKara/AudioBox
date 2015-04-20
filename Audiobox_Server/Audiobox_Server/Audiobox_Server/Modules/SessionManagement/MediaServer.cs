using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Audiobox_Server.General;

namespace Audiobox_Server.Modules.SessionManagement
{
    /// <summary>
    /// Class which represents an individual MediaServer Instances.
    /// Each MediaServer represent one individual stream.
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class MediaServer
    {
        public delegate void NextTrackHandler(string sid);
        public event NextTrackHandler NextTrack;

        private MemoryStream globalBuffer;
        FileStream currentFileStream;

        private HttpListener server;
        private Thread serverThread;
        private Thread bufferThread;

        private int port;
        private bool paused;
        private long pausedPosition;
        private string sid;

        /// <summary>
        /// Standard Constructor for MediaServer instances
        /// </summary>
        public MediaServer(string sessionId)
        {
            server = new HttpListener();

            this.port = SessionManager.GetNextFreePort();
            sid = sessionId;

            globalBuffer = new MemoryStream();
            globalBuffer.Position = 0;
            pausedPosition = 0;
            paused = true;

            server.Prefixes.Add(Actions.BuildUrlString(sessionId, port,'l'));
            server.Prefixes.Add(Actions.BuildUrlString(sessionId, port, 'e'));
        }

        /// <summary>
        /// Handling method for the case that the current Track is over and must be replaced
        /// </summary>
        public void OnNextTrack()
        {
            if (NextTrack != null)
            {
                NextTrack(sid);
            }
        }

        /// <summary>
        /// Starts a new MediaServer instance with all its threads
        /// </summary>
        public void Start()
        {
            server.Start();

            serverThread = new Thread(RunServer);
            serverThread.IsBackground = true;
            serverThread.Start();

            bufferThread = new Thread(StartBufferThread);
            bufferThread.IsBackground = true;
            bufferThread.Start();
        }

        /// <summary>
        /// Stops the MediaServer instance
        /// </summary>
        public void Stop()
        {
            server.Stop();

            if (serverThread != null && bufferThread != null)
            {
                if (serverThread.ThreadState == ThreadState.Running)
                {
                    serverThread.Abort();
                }
                if (bufferThread.ThreadState == ThreadState.Running)
                {
                    bufferThread.Abort();
                }
            }

            currentFileStream = null;
            SessionManager.ReleasePort(this.port);
        }

        /// <summary>
        /// Pauses the Mediaserver
        /// </summary>
        public void Pause()
        {
            this.paused = true;
        }

        public int GetPortNumber()
        {
            return this.port;
        }

        /// <summary>
        /// Clears the global buffer from all its contents
        /// </summary>
        public void ClearBuffer()
        {
            this.globalBuffer.Capacity = 0;
            this.globalBuffer.Position = 0;
        }

        /// <summary>
        /// Runs the actual server instance with the given Method
        /// </summary>
        private void RunServer()
        {
            StartFileStreamServer();
        }

        /// <summary>
        /// Method that attempts reading a file from the hard disk. 
        /// Returns a filestream in case of success
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private FileStream TryReading(string filename)
        {
            try
            {
                return File.OpenRead(GeneralObjects.SESSION_FOLDERNAME + "\\" + this.sid + "\\" + filename);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Thread-Method which handles the preserved buffering of files for the global buffer
        /// </summary>
        private void StartBufferThread()
        {
            Thread.Sleep(50);
            while (true)
            {
                string currentFileName = string.Empty;
                MemoryStream tmp = new MemoryStream();

                /// TEST
                while (SessionManager.SessionExists(sid))
                {
                    while (SessionManager.FindSessionBySessionId(sid).Playlist.HasCurrentTrack())
                    {
                        string previousFileName = currentFileName;
                        currentFileName = SessionManager.FindSessionBySessionId(sid).Playlist.CurrentTrack.Title + ".mp3";
                        bool mustWrite = false;

                        if (previousFileName != currentFileName)
                        {
                            currentFileStream = null;

                            while (currentFileStream == null)
                            {
                                currentFileStream = TryReading(currentFileName);
                            }

                            if (tmp.Length != currentFileStream.Length)
                            {
                                tmp = new MemoryStream();
                                currentFileStream.CopyTo(tmp);
                                tmp.Position = 0;
                                mustWrite = true;
                            }
                        }

                        if (mustWrite)
                        {
                            byte[] buffer = new byte[256 * 1024];
                            int read;

                            globalBuffer.Position = 0;
                            globalBuffer.SetLength(0);
                            globalBuffer.Capacity = 0;

                            while ((read = tmp.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                globalBuffer.Write(buffer, 0, read);
                            }
                            globalBuffer.Position = 0;

                            mustWrite = false;
                        }
                        Thread.Sleep(1);
                    }
                    Thread.Sleep(1);
                }
            }
        }

        /// <summary>
        /// Returns all URL to which the server is listening
        /// </summary>
        /// <returns></returns>
        public List<string> GetServerIdentification()
        {
            return this.server.Prefixes.ToList();
        }

        /// <summary>
        /// Method to read a 64KB chunk from the GlobalBuffer 
        /// </summary>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        private byte[] Get64KChunk(out int chunkSize)
        {
            byte[] chunk = new byte[64 * 1024];
            chunkSize = globalBuffer.Read(chunk, 0, chunk.Length);
            return chunk;
        }

        /// <summary>
        /// Code for a FileStreamServer-Thread
        /// </summary>
        private void StartFileStreamServer()
        {
            while (true)
            {
                HttpListenerContext output;
                try
                {
                    output = server.GetContext();
                }
                catch 
                {
                    break;
                }

                if (output.Request != null)
                {
                    paused = false;
                }

                var response = output.Response;

                globalBuffer.Position = pausedPosition;
                response.SendChunked = true;
                response.ProtocolVersion = new Version("1.0");
                response.ContentType = new System.Net.Mime.ContentType("audio/mpeg").ToString();

                byte[] buffer = new byte[64 * 1024];

                using (BinaryWriter bw = new BinaryWriter(response.OutputStream))
                {
                    while (true)
                    {
                        while (!paused)
                        {
                            if (SessionManager.FindSessionBySessionId(this.sid).isActive == false)
                            {
                                SessionManager.FindSessionBySessionId(this.sid).isActive = true;
                                SessionManager.OnSessionStatusChanged();
                            }
                            try
                            {
                                int chunkSize = 0;
                                byte[] chunk = Get64KChunk(out chunkSize);

                                bw.Write(chunk, 0, chunk.Length);

                                // DEBUG: Prints the current buffer position of the stream to the LogConsole. 
                                // ATTENTION: Too many invokes will break the LogConsole and crash the server with multiple exceptions
                                // LogConsole.PrintBufferStatus((int)globalBuffer.Position, (int)globalBuffer.Length);

                                if (chunkSize < chunk.Length)
                                {
                                    OnNextTrack();
                                    Thread.Sleep(3000);
                                    globalBuffer.Position = 0;
                                 
                                }
                            }
                            catch
                            {
                                HttpListenerContext emptyContext = null;
                                output = emptyContext;
                                paused = true;
                                SessionManager.FindSessionBySessionId(this.sid).isActive = false;
                                SessionManager.OnSessionStatusChanged();
                                this.pausedPosition = globalBuffer.Position;
                            }
                        }

                        if(paused)
                        {
                            break;
                        }
                    }
                }
            }
        }

        #region DEPRECATED_METHODS

        /// <summary>
        /// Code for a FileStreamServer-Thread
        /// </summary>
        private void StartNonPausableFileStreamServer()
        {
            while (true)
            {
                HttpListenerContext output = server.GetContext();
                var response = output.Response;

                globalBuffer.Position = 0;
                response.ContentLength64 = 800000000;
                response.SendChunked = false;
                // response.ContentType = System.Net.Mime.MediaTypeNames.Application.Octet;
                response.ContentType = new System.Net.Mime.ContentType("audio/mpeg").ToString();
                response.AddHeader("Content-disposition", "attachment; filename=test3.mp3");

                byte[] buffer = new byte[64 * 1024];

                using (BinaryWriter bw = new BinaryWriter(response.OutputStream))
                {
                    while (true)
                    {
                        int chunkSize = 0;
                        byte[] chunk = Get64KChunk(out chunkSize);

                        bw.Write(chunk, 0, chunk.Length);

                        // DEBUG: Prints the current buffer position of the stream to the LogConsole. 
                        // ATTENTION: Too many invokes will break the LogConsole and crash the server with multiple exceptions
                        // LogConsole.PrintBufferStatus((int)globalBuffer.Position, (int)globalBuffer.Length);

                        if (chunkSize < chunk.Length)
                        {
                            int oldGlobalPos = (int)globalBuffer.Position;
                            OnNextTrack();
                            Thread.Sleep(3000);
                            globalBuffer.Position = (long)oldGlobalPos;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// OBSOLETE: 
        /// Has been created just for test-puposes on how a http-listener works
        /// </summary>
        private void StartTextualServer()
        {
            while (true)
            {
                HttpListenerContext output = server.GetContext();
                string msg = "Listener Running";
                output.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
                output.Response.StatusCode = (int)HttpStatusCode.OK;
                using (Stream stream = output.Response.OutputStream)
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(msg);
                    }
                }
            }
        }

        /// <summary>
        /// Logic for a FileStreamServer-Instance // Abridged from the textual concept
        /// DEPRECATED. USE "StartFileStreamServer()" instead
        /// </summary>
        private void StartOldFileStreamServer()
        {
            while (true)
            {
                HttpListenerContext output = server.GetContext();
                var response = output.Response;

                /// FILESTREAM WHICH IS READING FROM THE GLOBAL MEDIASERVER-STREAM
                using (MemoryStream stream = globalBuffer)
                {
                    stream.Position = 0;

                    // response.ContentLength64 = stream.Length;
                    response.ContentLength64 = stream.Length * 3;
                    response.SendChunked = false;
                    response.ContentType = System.Net.Mime.MediaTypeNames.Application.Octet;
                    response.AddHeader("Content-disposition", "attachment; filename=test3.mp3");
                    
                    byte[] buffer = new byte[64 * 1024];
                    int read;

                    using (BinaryWriter bw = new BinaryWriter(response.OutputStream))
                    {
                        while (true)
                        {
                            read = stream.Read(buffer, 0, buffer.Length);
                            bw.Write(buffer, 0, read);

                            if (stream.Position == stream.Length)
                            {
                                OnNextTrack();
                                Thread.Sleep(500);
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}