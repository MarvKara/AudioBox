using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Audiobox_Server.General;
using Audiobox_Server.Modules.SessionManagement.Objects;

namespace Audiobox_Server.Modules.SessionManagement
{
    /// <summary>
    /// Filemanager-Class which controls the contents of a sessions 
    /// individual file-folder and reports changes to the sessionmanager
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class FileManager
    {
        public delegate void NewTrackHandler(string sessionID, Track track);
        public event NewTrackHandler NewTrack;

        public string SessionID { get; set; }
        public string DirectoryPath { get; set; }

        private Thread fileManagerThread;

        public FileManager(string sessionID)
        {
            this.SessionID = sessionID;
            this.DirectoryPath = GeneralObjects.SESSION_FOLDERNAME +"/"+ sessionID;

            fileManagerThread = new Thread(FileManagerThread);
            fileManagerThread.IsBackground = true;
            fileManagerThread.Start();
        }

        /// <summary>
        /// Handling method for new Tracks
        /// </summary>
        public void OnNewTrack(Track track)
        {
            if (NewTrack != null)
            {
                NewTrack(SessionID, track);
            }
        }

        /// <summary>
        /// The code for the actual FileManagerThread
        /// </summary>
        public void FileManagerThread()
        {
            List<string> previousfileList = new List<string>();
            List<string> newFileList;
            while (true)
            {
                Thread.Sleep(20); // Untested (May be reducing processor usage by ~50%)
                if (Directory.Exists(this.DirectoryPath))
                {
                    try
                    {
                        newFileList = Directory.GetFiles(this.DirectoryPath).ToList();
                    }
                    catch
                    {
                        continue;
                    }
                    if (newFileList.Count > previousfileList.Count)
                    {
                        string newest = NewestTrack(previousfileList, newFileList);
                        previousfileList = newFileList;
                        OnNewTrack(new Mp3Track(ExtractFileName(newest), Track.GenerateUniqueId()));
                    }
                }
            }
        }

        /// <summary>
        /// Returns the path of the newest track in the folder
        /// </summary>
        /// <param name="previousList"></param>
        /// <param name="newList"></param>
        /// <returns></returns>
        private static string NewestTrack(List<string> previousList, List<string> newList)
        {
            foreach (string track in newList)
            {
                if (!previousList.Contains(track))
                {
                    return track;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Extracts the filename from a given path
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string ExtractFileName(string input)
        {
            string output = Path.GetFileName(input);
            return output;
        }
    }
}