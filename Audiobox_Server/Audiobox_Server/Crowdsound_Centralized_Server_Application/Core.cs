using System;
using System.Threading;
using Crowdsound_Centralized_Server_Application.Modules;
using Crowdsound_Centralized_Server_Application.Modules.ClientSocketInterface;
using Crowdsound_Centralized_Server_Application.Modules.DeviceManagement;
using Crowdsound_Centralized_Server_Application.Modules.Reporting;
using Crowdsound_Centralized_Server_Application.Support;
using GeneralSupportLibrary;

namespace Crowdsound_Centralized_Server_Application
{
    /// <summary>
    /// The central Core Class which calls and controls all other classes
    /// #################################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public static class Core
    {
        public static bool EchoModeOn { get; set; }

        [STAThread]
        private static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                Thread.Sleep(1);
                UserInputInterpreter.Read(Console.ReadLine());
            }
        }

        private static void Initialize()
        {
            Console.WriteLine("INIT...");
            Thread.Sleep(666);

            RandomOperations.Initialize();
            UserInputInterpreter.Initialize();
            ClientSocketInterface.Initialize();
            MobileDeviceManagement.Initialize();
            EchoModeOn = false;
            //_gui = new MainForm();
            //Settings.Initialize();

            Console.WriteLine("INIT COMPLETE...");
            Console.Title = "Crowdsound CSA " + About.VERSION_NUMBER;
            ConsoleHelper.PrintProgramIdent();
        }

        internal static string SwitchEchoMode()
        {
            if (!EchoModeOn)
            {
                EchoModeOn = true;
                return "on";
            }
            else
            {
                EchoModeOn = false;
                return "off";
            }
        }
    }
}