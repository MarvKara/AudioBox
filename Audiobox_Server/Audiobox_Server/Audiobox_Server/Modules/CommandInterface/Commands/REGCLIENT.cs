using Audiobox_Server.Modules.AudioboxConsole;
using Audiobox_Server.Modules.UserManagement;
using Audiobox_Server.Modules.SessionManagement;

namespace Audiobox_Server.Modules.CommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command REGCLIENT
    /// Parameter1 :: USERID
    /// Parameter2 :: SESSIONID
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class REGCLIENT : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 2;
        public static readonly UserAuthorization REQUIRED_AUTHORIZATION = UserAuthorization.Unassingned;

        public REGCLIENT(string keyword, string[] parameters, UserAuthorization userAuthorization)
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
            if (SessionManager.SessionExists(this.Parameters[1]))
            {
                UserManager.AssignUser(this.Parameters[1], this.Parameters[0], false);
                LogConsole.WriteLine("// EXECUTED " + this.CommandWord + " " + this.Parameters[0] + " " + this.Parameters[1] + " //");
                LogConsole.WriteLine("// ASSIGNED USER #" + this.Parameters[0] + " TO SESSION " + this.Parameters[1] + " //");
                LogConsole.Break();
                return string.Empty;
            }
            else
            {
                LogConsole.WriteLine("// EXECUTED " + this.CommandWord + " " + this.Parameters[0] + " " + this.Parameters[1] + " //");
                LogConsole.WriteLine("// ERROR ::: SESSION " + this.Parameters[1] + " DOES NOT EXIST //");
                LogConsole.Break();
                return "ERROR";
            }
        }
    }
}