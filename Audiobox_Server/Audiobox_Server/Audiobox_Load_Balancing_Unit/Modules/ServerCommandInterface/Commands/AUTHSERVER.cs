using Crowdsound_Master_Server_Application.Modules.UserManagement;
using Crowdsound_Master_Server_Application.Modules.ConnectionInterface;
using Crowdsound_Master_Server_Application.Modules.ServerManagement;

namespace Crowdsound_Master_Server_Application.Modules.ServerCommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command AUTHSERVER
    /// Parameter1 :: TEMPORARYID
    /// Parameter2 :: SUPPOSEDID
    /// Parameter3 :: SECRET
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public class AUTHSERVER : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 3;

        public AUTHSERVER(string keyword, string[] parameters)
            : base(keyword, parameters)
        {
            ///
        }

        public bool IsCorrectFormat(int parameters)
        {
            return HasCorrectFormat(parameters, NEEDS_PARAMETERS, HAS_PARAMETERS);
        }

        public string Execute(out string commandRequest)
        {
            string message = Core.ServerManager.AuthentificateServer(Parameters[0], Parameters[1], Parameters[2]);
            if (message == "CONNECTION ESTABLISHED")
            {
                commandRequest = "TAKEIDENT";
            }
            else
            {
                commandRequest = "REAUTHSERVER";
            }
            return message;
        }
    }
}