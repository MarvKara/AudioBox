using System;
using System.Threading;
using System.Windows.Forms;
using Crowdsound_Slave_Server_Application.Forms;
using Crowdsound_Slave_Server_Application.Support;
using Crowdsound_Slave_Server_Application.Modules.ConnectionInterface;
using System.Text;
using Crowdsound_Slave_Server_Application.Modules.Reporting;

namespace Crowdsound_Slave_Server_Application
{
    /// <summary>
    /// The Central Core Class which calls and controls all other classes
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class Core
    {
        private static MainForm gui;
        public static MSAConnection MSAConnection { get; set; }

        [STAThread]
        static void Main()
        {
            #region // <VAR>

            string userInput = string.Empty;

            #endregion

            #region //<INIT>

            Console.WriteLine("INIT...");
            Thread.Sleep(666);

            gui = new MainForm();

            Settings.Initialize();

            Console.WriteLine("INIT COMPLETE...");
            Console.Title = "Crowdsound SSA " + About.VERSION_NUMBER;
            ConsoleHelper.PrintProgramIdent();

            AttemptLocateMSA();

            #endregion

            while(true)
            {
                userInput = Console.ReadLine();

                if (userInput == "exec gui")
                {
                    ConsoleHelper.PrintExecStatement(userInput);
                    OpenGUI();
                }
                if (userInput == "exec msahookup")
                {
                    ConsoleHelper.PrintExecStatement(userInput);
                    AttemptLocateMSA();
                }
                if (userInput == "exec disconnect")
                {
                    Console.WriteLine("EXEC DISCONNECT...");
                    Console.WriteLine("~done");
                    MSAConnection.Disconnect();
                }
                if (userInput == "transmit")
                {
                    Console.WriteLine("enter message\n");
                    string message = Console.ReadLine();
                    MSAConnection.SendCommand(message);
                }
            }
        }

        private static void AttemptLocateMSA()
        {
            MSAConnection newConnection;
            if (HookupToMSA(out newConnection))
            {
                MSAConnection = newConnection;
                ConsoleHelper.PrintMSAFound();
            }
            else
            {
                ConsoleHelper.PrintMSANotFound();
            }
        }

        private static bool HookupToMSA(out MSAConnection connection)
        {
            int msaport = 12666;
            MSAConnection localMSA = new MSAConnection("127.0.0.1", msaport);
            MSAConnection lanMSA = new MSAConnection("192.168.1.36", msaport);
            MSAConnection wwwMSA = new MSAConnection("outcast-prophets.no-ip.org", msaport);

            try
            {
                ConsoleHelper.PrintSearching("WWW");
                wwwMSA.Connect();
                connection = wwwMSA;
                return true;
            }
            catch
            {
                try
                {
                    ConsoleHelper.PrintSearching("LAN");
                    lanMSA.Connect();
                    connection = lanMSA;
                    return true;
                }
                catch
                {
                    try
                    {
                        ConsoleHelper.PrintSearching("LOCALHOST");
                        localMSA.Connect();
                        connection = localMSA;
                        return true;
                    }
                    catch
                    {
                        connection = null;
                        return false;
                    }
                }
            }
        }

        private static void OpenGUI()
        {
            Thread guiThread = new Thread(() => gui.ShowDialog());
            guiThread.SetApartmentState(ApartmentState.STA);
            guiThread.IsBackground = true;
            guiThread.Start();
        }
    }
}
