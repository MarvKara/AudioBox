﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdsound_Slave_Server_Application.Support;

namespace Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command REAUTHSERVER
    /// Parameter 1 :: Server ID
    /// Parameter 2 :: Secret
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public class REAUTHSERVER : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 2;

        public REAUTHSERVER(string keyword, string[] parameters)
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
            Settings.SERVER_ID = Parameters[0];
            Settings.SECRET = Parameters[1];

            try
            {
                string commandString = "AUTHSERVER " + "NONE " + Settings.SERVER_ID + " " + Settings.SECRET;
                Core.MSAConnection.SendCommand(commandString);
            }
            catch
            {
                return "CONNECTION ERROR";
            }

            return string.Empty;
        }
    }
}
