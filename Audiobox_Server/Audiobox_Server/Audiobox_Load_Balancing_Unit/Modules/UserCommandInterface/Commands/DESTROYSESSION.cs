﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdsound_Master_Server_Application.Modules.UserManagement;

namespace Crowdsound_Master_Server_Application.Modules.CommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command DESTROYSESSION
    /// Parameter1 :: USERID
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public class DESTROYSESSION : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 1;
        public static readonly UserAuthorization REQUIRED_AUTHORIZATION = UserAuthorization.Assigned;

        public DESTROYSESSION(string keyword, string[] parameters, UserAuthorization userAuthorization)
            : base(keyword, parameters, userAuthorization)
        {
            ///
        }

        public bool IsCorrectFormat(int parameters)
        {
            return HasCorrectFormat(parameters, NEEDS_PARAMETERS, HAS_PARAMETERS);
        }

        public bool IsAuthorized()
        {
            return HasAuthorization(this.UserAuthorization, REQUIRED_AUTHORIZATION);
        }

        public string Execute()
        {
            string message = string.Empty;

            return message;
        }
    }
}
