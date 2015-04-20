using System;
using System.Threading;
using System.Windows.Forms;
using Crowdsound_Master_Server_Application.Forms;
using Crowdsound_Master_Server_Application.Support;
using Crowdsound_Master_Server_Application.Modules.ConnectionInterface;
using Crowdsound_Master_Server_Application.Modules.ServerManagement;
using Crowdsound_Master_Server_Application.Modules.Reporting;
using Crowdsound_Master_Server_Application.Modules.Database;
using System.Collections.Generic;

namespace Crowdsound_Master_Server_Application
{
    /// <summary>
    /// The Central Core Class which calls and controls all other classes
    /// #################################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class Core
    {
        public static ServerManager ServerManager { get; set; }
        public static bool EchoOn { get; set; }
        private static MainForm _gui;

        [STAThread]
        public static void Main()
        {
            #region//<VAR>

            var userInput = string.Empty;
            EchoOn = false;

            #endregion

            #region //<INIT>

            Console.WriteLine("INIT...");
            Thread.Sleep(666);

            DBAccess.Initialize();
            _gui = new MainForm();
            ServerManager = new ServerManager();
            ServerManager.Initialize();
            ServerManager.ServerListUpdate += new Modules.ServerManagement.ServerManager.ServerListUpdateHandler(ServerManager_ServerListUpdate);
            ServerSocketInterface.Initialize();
            Settings.Initialize();

            Console.WriteLine("INIT COMPLETE...");
            Console.Title = "Crowdsound MSA " + About.VERSION_NUMBER;
            ConsoleHelper.PrintProgramIdent();

            #endregion

            while(true)
            {
                Thread.Sleep(1);
                userInput = Console.ReadLine();
                if (userInput == "exec _gui")
                {
                    Console.WriteLine("EXEC GUI...");
                    OpenGUI();
                }
                if (userInput == "exec saveall")
                {
                    Console.WriteLine("EXEC SAVEALL...");
                    DBAccess.SaveServers(Core.ServerManager.ExtractServerInstances());
                }
                if (userInput == "exec slist")
                {
                    Console.WriteLine("EXEC SLIST");
                    // TODO
                }
                if (userInput == "exec swecho")
                {
                    Console.WriteLine("EXEC SWECHO");
                    EchoOn = true;
                }
            }
        }

        static void ServerManager_ServerListUpdate(List<SlaveServer> servers)
        {
            _gui.UpdateServerList(servers);
        }

        private static void OpenGUI()
        {
            Thread guiThread = new Thread(() => _gui.ShowDialog());
            guiThread.SetApartmentState(ApartmentState.STA);
            guiThread.IsBackground = true;
            guiThread.Start();
        }
    }
}