﻿using System;
using Audiobox_Server.Modules.SessionManagement;
using Audiobox_Server.Modules.UserManagement;

namespace Audiobox_Server.Modules.CommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command GETPLAYLISTUPDATETIME
    /// Parameter1 :: USERID
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class GETPLAYLISTUPDATETIME : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 1;
        public static readonly UserAuthorization REQUIRED_AUTHORIZATION = UserAuthorization.Assigned;

        public GETPLAYLISTUPDATETIME(string keyword, string[] parameters, UserAuthorization userAuthorization)
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
            if (SessionManager.FindSessionByUserId(this.Parameters[0]) != null)
            {
                TimeSpan difference = DateTime.Now - SessionManager.FindSessionByUserId(this.Parameters[0]).Playlist.LastUpdateTime;
                int ms = (int)difference.TotalMilliseconds;
                message = ms.ToString();
            }
            else
            {
                message = "ERROR";
            }
            return message;
        }
    }
}
