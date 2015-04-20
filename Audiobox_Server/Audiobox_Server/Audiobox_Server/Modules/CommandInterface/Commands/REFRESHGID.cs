using Audiobox_Server.Modules.AudioboxConsole;
using Audiobox_Server.Modules.UserManagement;

namespace Audiobox_Server.Modules.CommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command REFRESHGID
    /// Parameter1 :: USERID
    /// Parameter2 :: GOOGLEID
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    class REFRESHGID : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 2;
        public static readonly UserAuthorization REQUIRED_AUTHORIZATION = UserAuthorization.Unassingned;

        public REFRESHGID(string keyword, string[] parameters, UserAuthorization userAuthorization)
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
            string preUpdateGid = UserManager.UpdateUser(this.Parameters[0], this.Parameters[1]);
            LogConsole.WriteLine("// EXECUTED " + this.CommandWord + " " + this.Parameters[0] + " //");
            LogConsole.WriteLine("// CHANGED GOOGLEID ON USER #" + this.Parameters[0] + " ::: " + preUpdateGid + " >>> " + this.Parameters[1] + " //");
            LogConsole.Break();
            return message;
        }
    }
}