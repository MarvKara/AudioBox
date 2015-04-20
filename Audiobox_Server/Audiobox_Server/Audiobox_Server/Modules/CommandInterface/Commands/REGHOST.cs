using Audiobox_Server.Modules.AudioboxConsole;
using Audiobox_Server.Modules.SessionManagement.Objects;
using Audiobox_Server.Modules.SessionManagement;
using Audiobox_Server.Modules.UserManagement;

namespace Audiobox_Server.Modules.CommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command REGHOST
    /// Parameter1 :: USERID
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class REGHOST : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 1;
        public static readonly UserAuthorization REQUIRED_AUTHORIZATION = UserAuthorization.Unassingned;

        public REGHOST(string keyword, string[] parameters, UserAuthorization userAuthorization)
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
            LogConsole.Break();
            string message = string.Empty;
            Session newSession = new Session();

            if (SessionManager.AddSession(newSession, this.Parameters[0], true) == true)
            {
                LogConsole.Write(newSession.Details());
                message = newSession.Id + "&" + newSession.MediaServer.GetPortNumber().ToString();
            }
            else
            {
                newSession.Stop();
                newSession.Terminate();
                LogConsole.WriteLine("// EXECUTED " + this.CommandWord + " " + this.Parameters[0] + " //");
                LogConsole.WriteLine("// ERROR ::: USER IS ALREADY REGISTERD AS HOST " + " //");
                LogConsole.Break();
                message = "ERROR";
            }
            return message;
        }
    }
}