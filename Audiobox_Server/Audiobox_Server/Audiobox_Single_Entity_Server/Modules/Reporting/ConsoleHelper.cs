using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Crowdsound_Slave_Server_Application.Support;

namespace Crowdsound_Slave_Server_Application.Modules.Reporting
{
    public static class ConsoleHelper
    {
        private static string tabr = "\n\t";
        private static string br = "\n";
        private static string seper = "-------------------------------";

        public static void PrintProgramIdent()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(br + seper);
            Console.WriteLine("**   Crowdsound SSA " + About.VERSION_NUMBER + "     **");
            Console.WriteLine(seper);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void PrintNewConnection(Socket connection)
        {
            string remoteIP = connection.RemoteEndPoint.ToString().Split(':')[0];
            string callbackPort = connection.RemoteEndPoint.ToString().Split(':')[1];

            Console.WriteLine(br + seper);

            Console.WriteLine("New Connection from:" + tabr + "IP: " + remoteIP + tabr +
                "Callback-Port: " + callbackPort + tabr +
                "On Port: " + ((IPEndPoint)connection.LocalEndPoint).Port.ToString());
        }

        public static void PrintServerConEstablished(string ip, string id)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Server Connection established: " +tabr + 
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

        public static void PrintRecievedResponse(string rawMessage)
        {
            try
            {
                string commandRequest = rawMessage.Split('$')[0];
                string response = rawMessage.Split('$')[1];

                Console.WriteLine(br + seper);
                Console.WriteLine("Received Response from MSA: " + tabr +
                    "CMD Requested: " + commandRequest + tabr +
                    "Response: " + response);
            }
            catch
            {
                Console.WriteLine(br + seper);
                Console.WriteLine("Received Response from MSA: " + tabr +
                    "Response: " + rawMessage);
            }
        }

        public static void PrintExecStatement(string statement)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("EXEC " + statement.ToLower());
            Console.WriteLine("~done");
        }

        public static void PrintMSAFound()
        {
            Console.WriteLine("MSA Located.");
            Console.WriteLine("Establishing Connection...");
        }

        public static void PrintMSANotFound()
        {
            Console.WriteLine("Failed to Locate MSA");
            Console.WriteLine("Check your Connection...");
        }

        public static void PrintCmdError(string senderID, string command)
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Invalid Command: " + tabr +
                "Sender: " + senderID + tabr +
                "CMD: " + command);
        }

        public static void PrintMSAConnectionClosed()
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("MSA Connection closed ");
            Console.WriteLine("Server is now offline");
        }

        public static void PrintSearching(string scope)
        {
            if (scope == "WWW")
            {
                Console.WriteLine(br + seper);
            }
            Console.WriteLine("Locating MSA... --> [" + scope + "]");
        }

        public static void PrintIdentityAndMatchConsole()
        {
            Console.WriteLine(br + seper);
            Console.WriteLine("Registered on MSA as: " + tabr +
                "ID: " + Settings.SERVER_ID + tabr);
            Console.WriteLine(Settings.SERVER_ID + " is now online");
            Console.Title += "               ID: " + Settings.SERVER_ID + " ::   Status: Online"; 
        }
    }
}
