using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Crowdsound_Master_Server_Application.Modules.Reporting;
using Crowdsound_Master_Server_Application.Modules.ServerCommandInterface;

namespace Crowdsound_Master_Server_Application.Modules.ConnectionInterface
{
    public class ServerConnection
    {
        private ServerSocket Connection { get; set; }
        private Thread ConnectionThread { get; set; }
        public string CoherentServerID { get; private set; }
        private bool Muted { get; set; }

        public ServerConnection(Socket connection, string serverID)
        {
            this.CoherentServerID = serverID;
            this.Muted = false;
            this.Connection = new ServerSocket(connection);
            this.ConnectionThread = new Thread(ConnectionRoutine);
            this.ConnectionThread.IsBackground = true;
            this.ConnectionThread.Start();
        }

        public void Bind(string serverID)
        {
            this.CoherentServerID = serverID;
        }

        public string GetIpAddress()
        {
            return this.Connection.GetIpAddress();
        }

        public string GetCallbackPort()
        {
            return this.Connection.GetCallbackPort();
        }

        public string GetLocalPort()
        {
            return this.Connection.GetLocalPort();
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

        public void Close()
        {
            this.Connection.Disconnect();
        }

        public void SendCommandRequest(string commandRequest, string response)
        {
            string fullRequest = commandRequest + "$" + response;
            this.Connection.Send(Encode(fullRequest));
        }

        public void SendPlainText(string message)
        {
            this.Connection.Send(Encode(message));
        }

        private void ConnectionRoutine()
        {
            while (this.Connection.IsAlive())
            {
                try
                {
                    string message = string.Empty;
                    byte[] data = new byte[256];
                    if (this.Connection.IsReceiving(out data))
                    {
                        message = Decode(data);

                        if (!Core.EchoOn)
                        {
                            ConsoleHelper.PrintRecievedCmd(this.CoherentServerID, message);

                            ICommand cmd;
                            try
                            {
                                cmd = CommandParser.Parse(message);
                                string followupCmdRequest = string.Empty;
                                string response = CommandExecutor.ExecuteCommand(cmd, out followupCmdRequest);

                                if (followupCmdRequest != "NONE")
                                {
                                    this.RespondWithRequest(followupCmdRequest, response);
                                }
                                else
                                {
                                    this.Respond(response);
                                }
                            }
                            catch
                            {
                                ConsoleHelper.PrintCmdError(this.CoherentServerID, message);
                            }
                        }
                        else
                        {
                            this.Respond(message);
                        }
                    }
                }
                catch
                {
                    if (!Muted)
                    {
                        ConsoleHelper.PrintConnectionClosed(this.CoherentServerID, this.Connection.GetIpAddress());
                    }
                    break;
                }
            }
            ConsoleHelper.PrintConnectionClosed(this.CoherentServerID, this.Connection.GetIpAddress());
        }

        public void RespondWithRequest(string commandRequest, string response)
        {
            this.SendCommandRequest(commandRequest, response);
        }

        public void Respond(string response)
        {
            this.SendPlainText(response);
        }

        public void Mute()
        {
            this.Muted = true;
        }

        public bool IsAlive()
        {
            return this.Connection.IsAlive();
        }
    }
}