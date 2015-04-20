using Crowdsound_Master_Server_Application.Modules.UserManagement;

namespace Crowdsound_Master_Server_Application.Modules.CommandInterface.Commands
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
            return string.Empty;
        }
    }
}