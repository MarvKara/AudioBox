using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Crowdsound_Master_Server_Application.Modules.ServerManagement;
using Crowdsound_Master_Server_Application.Modules.Reporting;
using System.Text;

namespace Crowdsound_Master_Server_Application.Modules.ConnectionInterface
{
    public static class ServerSocketInterface
    {
        private static int serverPort = 12666;
        private static int sleepTime = 200;
        private static IPAddress ipaddress = IPAddress.Any;
        private static Thread interfaceThread;

        public static void Initialize()
        {
            interfaceThread = new Thread(Start);
            interfaceThread.IsBackground = true;
            interfaceThread.Start();
        }

        private static void Start()
        {
            TcpListener listener = new TcpListener(ipaddress, serverPort);
            ConsoleHelper.PrintSSIStart(serverPort.ToString());

            try
            {
                listener.Start();
                while (true)
                {
                    Thread.Sleep(10);
                    while (!listener.Pending())
                    {
                        Thread.Sleep(sleepTime);
                    }
                    Socket incoming = listener.AcceptSocket();

                    string authorizationId = Core.ServerManager.GenerateAuthentificationId();
                    ServerConnection connection = new ServerConnection(incoming, authorizationId);
                    ConsoleHelper.PrintNewConnection(connection);

                    Core.ServerManager.QueueConnectionForAuthentification(connection);
                    connection.Respond("AUTHSERVER"+"$"+ authorizationId);
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("SSI Error. Connection Failed! >> " + ex.Message);
            }
        }
    }
}
