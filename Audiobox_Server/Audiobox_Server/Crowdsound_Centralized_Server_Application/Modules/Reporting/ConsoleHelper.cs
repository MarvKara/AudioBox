using System;
using Crowdsound_Centralized_Server_Application.Modules.ClientSocketInterface;
using Crowdsound_Centralized_Server_Application.Support;

namespace Crowdsound_Centralized_Server_Application.Modules.Reporting
{
    public static class ConsoleHelper
    {
        private static string tabr = "\n\t";
        private static string br = "\n";
        private static string seper = "-------------------------------";

        public static void PrintProgramIdent()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(br + seper);
            Console.WriteLine("**   Crowdsound CSA " + About.VERSION_NUMBER + "   **");
            Console.WriteLine(seper);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintCsiModuleStart(string port)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Client Socket Interface [CSI] running on port: " + port);
        }

        public static void PrintConnectionClosed(string id, string ip)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Server Connection closed " + tabr + 
                "IP: " + ip + tabr + 
                "ID: " + id);
        }

        public static void PrintServerListedForAuthentification(string id, string ip)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Connection listed for authentification: " + tabr +
                "IP: " + ip + tabr +
                "ID: " + id);
        }

        public static void PrintClientConEstablished(string imei, string id)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Client Connection established: " +tabr + 
                "IMEI: " + imei + tabr +
                "ID: " + id);
        }

        public static void PrintNewDeviceBound(string imei, string id)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Bound: New Device" + tabr +
                "IMEI: " + imei + tabr +
                "ID: " + id);
        }

        public static void PrintRecievedCmd(string senderID, string command)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Received Command: " + tabr +
                "Sender: " + senderID + tabr +
                "CMD: " + command);
        }

        public static void PrintCmdError(string senderId, string command)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Invalid Command: " + tabr +
                "Sender: " + senderId + tabr +
                "CMD: " + command);
        }

        internal static void PrintNewConnection(ClientConnection connection)
        {
            var remoteIP = connection.GetIpAddress();
            var callbackPort = connection.GetCallbackPort();

            Console.WriteLine(br + seper);

            Console.WriteLine("New Connection from:" + tabr + "IP: " + remoteIP + tabr +
                "Callback-Port: " + callbackPort + tabr +
                "On Port: " + connection.GetLocalPort());
        }
    }
}
