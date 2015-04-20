using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdsound_Slave_Server_Application.Support;
using Crowdsound_Slave_Server_Application.Modules.Reporting;

namespace Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command TAKEIDENT
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public class TAKEIDENT : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = false;
        public static readonly int NEEDS_PARAMETERS = 0;

        public TAKEIDENT(string keyword, string[] parameters)
            : base(keyword, parameters)
        {
            ///
        }

        public bool IsCorrectFormat(int parameters)
        {
            return HasCorrectFormat(parameters, NEEDS_PARAMETERS, HAS_PARAMETERS);
        }

        public string Execute()
        {
            Settings.SaveCurrent();
            ConsoleHelper.PrintIdentityAndMatchConsole();

            return "SILENCE";
        }
    }
}
