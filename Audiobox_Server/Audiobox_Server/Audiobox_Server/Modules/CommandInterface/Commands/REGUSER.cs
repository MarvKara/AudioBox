using Audiobox_Server.Modules.AudioboxConsole;
using Audiobox_Server.Modules.UserManagement;

namespace Audiobox_Server.Modules.CommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command REGUSER
    /// Parameter1 :: GOOGLEID
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class REGUSER : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 1;
        public static readonly UserAuthorization REQUIRED_AUTHORIZATION = UserAuthorization.None;

        public REGUSER(string keyword, string[] parameters, UserAuthorization userAuthorization)
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
            User newUser = UserManager.CreateUser(this.Parameters[0]);

            LogConsole.WriteLine("// EXECUTED " + this.CommandWord + " " + this.Parameters[0] + " //");
            LogConsole.WriteLine("// NEW USER: UID/GID " + " ::: " + newUser.UserId + " / " + newUser.GoogleId + " //");
            LogConsole.Break();

            return newUser.UserId;
        }
    }
}