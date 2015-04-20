using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Crowdsound_Master_Server_Application.Support;
using Crowdsound_Master_Server_Application.Modules.ConnectionInterface;
using Crowdsound_Master_Server_Application.Modules.ServerManagement;

namespace Crowdsound_Master_Server_Application.Modules.Reporting
{
    public static class ConsoleHelper
    {
        private static string tabr = "\n\t";
        private static string br = "\n";
        private static string seper = "-------------------------------";

        public static void PrintProgramIdent()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(br + seper);
            Console.WriteLine("**   Crowdsound MSA " + About.VERSION_NUMBER + "     **");
            Console.WriteLine(seper);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintSSIStart(string port)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("SSI running on ANY/" + port.ToString());
        }

        public static void PrintNewConnection(ServerConnection connection)
        {
            string remoteIP = connection.GetIpAddress();
            string callbackPort = connection.GetCallbackPort();

            Console.WriteLine(br + seper);

            Console.WriteLine("New Connection from:" + tabr + "IP: " + remoteIP + tabr +
                "Callback-Port: " + callbackPort + tabr +
                "On Port: " + connection.GetLocalPort());
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

        public static void PrintServerConEstablished(string ip, string id)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Server Connection established: " +tabr + 
                "IP: " + ip + tabr +
                "ID: " + id);
        }

        public static void PrintNewServerCreated(string ip, string id)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("New Server Created: " + tabr +
                "IP: " + ip + tabr +
                "ID: " + id);
        }

        public static void PrintRecievedCmd(string senderID, string command)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Received Command: " + tabr +
                "Sender: " + senderID + tabr +
                "CMD: " + command);
        }

        public static void PrintCmdError(string senderID, string command)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Invalid Command: " + tabr +
                "Sender: " + senderID + tabr +
                "CMD: " + command);
        }

        public static void PrintServerList()
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Servers Registered: " + tabr);
            foreach (SlaveServer server in Core.ServerManager.GetServerList())
            {
                /// TODO
            }
        }
    }
}
