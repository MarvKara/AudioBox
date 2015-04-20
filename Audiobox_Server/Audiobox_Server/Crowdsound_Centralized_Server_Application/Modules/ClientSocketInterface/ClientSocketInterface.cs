using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Crowdsound_Centralized_Server_Application.Modules.Reporting;
using Crowdsound_Centralized_Server_Application.Modules.DeviceManagement;
using GeneralSupportLibrary;

namespace Crowdsound_Centralized_Server_Application.Modules.ClientSocketInterface
{
    public static class ClientSocketInterface
    {
        private const int InterfacePort = 12666;
        private const int SleepTime = 50;
        private static readonly IPAddress Ipaddress = IPAddress.Any;
        private static Thread _interfaceThread;

        public static void Initialize()
        {
            _interfaceThread = new Thread(Start) {IsBackground = true};
            _interfaceThread.Start();
        }

        private static void Start()
        {
            var listener = new TcpListener(Ipaddress, InterfacePort);
            ConsoleHelper.PrintCsiModuleStart(InterfacePort.ToString());

            try
            {
                listener.Start();
                while (true)
                {
                    Thread.Sleep(1);
                    while (!listener.Pending())
                    {
                        Thread.Sleep(SleepTime);
                    }
                    var incoming = listener.AcceptSocket();

                    var authentificationId = GenerateAuthentificationId();
                    var connection = new ClientConnection(incoming, authentificationId);
                    ConsoleHelper.PrintNewConnection(connection);

                    MobileDeviceManagement.QueueConnectionForAuthentification(connection, authentificationId);
                    connection.Respond("AUTHDEVICE"+"$"+ authentificationId);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("CSI Error. Connection Failed! \n Reason: " + ex.Message);
            }
        }

        private static string GenerateAuthentificationId()
        {
            return "AUTH" + RandomOperations.GenerateRandomNumber(12);
        }
    }
}
