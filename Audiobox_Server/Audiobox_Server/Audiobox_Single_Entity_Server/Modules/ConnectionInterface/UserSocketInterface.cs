using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Crowdsound_Slave_Server_Application.Modules.ConnectionInterface
{
    /// <summary>
    /// Handles all Networking interaction with User-Clients
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public static class UserSocketInterface
    {
        private static int serverPort = 12666;
        private static int sleepTime = 200;
        private static IPAddress ipadress = IPAddress.Any;

        public static void Initialize()
        {
            /// TODO
        }

        public static void Start()
        {
            TcpListener listener = new TcpListener(ipadress, serverPort);
            System.Console.WriteLine("SSI running on ANY/" + serverPort.ToString());

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

                    Socket connection = listener.AcceptSocket();
                    System.Console.WriteLine("New Connection:\n\tIP:" + connection.RemoteEndPoint + "\n\tPort: " +
                        ((IPEndPoint)connection.LocalEndPoint).Port.ToString());

                    // UserManager integration
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("USI Error. Connection Failed! >> " + ex.Message);
            }
        }
    }
}
