using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Crowdsound_Slave_Server_Application.Modules.Reporting;
using Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface;
using Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface.Commands;

namespace Crowdsound_Slave_Server_Application.Modules.ConnectionInterface
{
    public class MSAConnection
    {
        private TCPConnection Connection { get; set; }
        private Thread ConnectionThread { get; set; }
        public bool IsTerminated { get; set; }

        public MSAConnection(string networkAdress, int port)
        {
            IsTerminated = false;
            ConnectionThread = new Thread(ConnectionRoutine);
            ConnectionThread.IsBackground = true;
            Connection = new TCPConnection(networkAdress, port);
        }

        public void Connect()
        {
            try
            {
                if (this.Connection.Connect())
                {
                    ConnectionThread.Start();
                }
                else
                {
                    throw new Exception("Attempt failed");
                }
            }
            catch
            {
                throw new Exception("Connection to MSA failed");
            }
        }

        public void Disconnect()
        {
            if (this.ConnectionThread.ThreadState == ThreadState.Running)
            {
                ConnectionThread.Abort();
            }
            this.IsTerminated = true;
            this.Connection.Disconnect();
        }

        private string Decode(byte[] data)
        {
            UTF8Encoding enc = new UTF8Encoding();
            string message = enc.GetString(data);
            message = message.TrimEnd('\0');
            return message;
        }

        private byte[] Encode(string content)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(content);
            return data;
        }

        private void ConnectionRoutine()
        {
            while (!this.IsTerminated)
            {
                while (this.Connection.IsAlive())
                {
                    try
                    {
                        byte[] data = new byte[256];
                        if (this.Connection.IsReceiving(out data))
                        {
                            string content = Decode(data);
                            if (!content.Contains("♥"))
                            {
                                ConsoleHelper.PrintRecievedResponse(content);

                                ICommand cmd;
                                string response;
                                try
                                {
                                    cmd = CommandParser.Parse(content);
                                    response = CommandExecutor.ExecuteCommand(cmd);

                                    if (response != "SILENCE")
                                    {
                                        this.SendCommand(response);
                                    }
                                }
                                catch 
                                {
                                    //
                                }
                            }
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
                this.IsTerminated = true;
                ConsoleHelper.PrintMSAConnectionClosed();
            }
        }

        public bool IsAlive()
        {
            return this.Connection.IsAlive();
        }

        public void RespondWithRequest(string commandRequest)
        {
            this.SendCommand(commandRequest);
        }

        public void Respond(string response)
        {
            this.SendPlainText(response);
        }

        public void SendCommand(string commandString)
        {
            this.Connection.Send(Encode(commandString));
        }

        public void SendPlainText(string message)
        {
            this.Connection.Send(Encode(message));
        }
    }
}