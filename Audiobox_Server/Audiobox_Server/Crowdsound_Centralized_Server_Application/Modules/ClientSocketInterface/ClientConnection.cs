using System.Net.Sockets;
using System.Text;
using System.Threading;
using Crowdsound_Centralized_Server_Application.Modules.Reporting;
using Crowdsound_Centralized_Server_Application.Modules.ServerCommandInterface;

namespace Crowdsound_Centralized_Server_Application.Modules.ClientSocketInterface
{
    public class ClientConnection
    {
        private DeviceSocket Connection { get; set; }
        private Thread ConnectionThread { get; set; }
        public string CoherentDeviceId { get; private set; }
        private bool Muted { get; set; }

        public ClientConnection(Socket connection, string deviceId)
        {
            this.CoherentDeviceId = deviceId;
            this.Muted = false;
            this.Connection = new DeviceSocket(connection);
            this.ConnectionThread = new Thread(ConnectionRoutine);
            this.ConnectionThread.IsBackground = true;
            this.ConnectionThread.Start();
        }

        public void Bind(string serverId)
        {
            this.CoherentDeviceId = serverId;
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
        
        private static string Decode(byte[] data)
        {
            var enc = new UTF8Encoding();
            var message = enc.GetString(data);
            message = message.TrimEnd('\0');
            return message;
        }

        private static byte[] Encode(string content)
        {
            var enc = new UTF8Encoding();
            var data = enc.GetBytes(content);
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
            while (Connection.IsAlive())
            {
                Thread.Sleep(1);
                try
                {
                    var message = string.Empty;
                    var data = new byte[512];
                    if (Connection.IsReceiving(out data))
                    {
                        message = Decode(data);

                        if (!Core.EchoModeOn)
                        {
                            ConsoleHelper.PrintRecievedCmd(CoherentDeviceId, message);

                            try
                            {
                                var cmd = CommandParser.Parse(message);
                                var followupCmdRequest = string.Empty;
                                var response = CommandExecutor.ExecuteCommand(cmd, out followupCmdRequest);

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
                                ConsoleHelper.PrintCmdError(CoherentDeviceId, message);
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
                        ConsoleHelper.PrintConnectionClosed(this.CoherentDeviceId, this.Connection.GetIpAddress());
                    }
                    break;
                }
            }
            ConsoleHelper.PrintConnectionClosed(this.CoherentDeviceId, this.Connection.GetIpAddress());
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