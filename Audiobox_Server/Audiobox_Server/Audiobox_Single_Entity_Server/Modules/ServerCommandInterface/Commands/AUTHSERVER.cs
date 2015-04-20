using Crowdsound_Slave_Server_Application.Modules.ConnectionInterface;
using System.Text;
using Crowdsound_Slave_Server_Application.Support;

namespace Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command AUTHSERVER
    /// Parameter1 :: TEMPORARYID
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public class AUTHSERVER : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 1;

        public AUTHSERVER(string keyword, string[] parameters)
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
            try
            {
                string commandString = "AUTHSERVER " + Parameters[0] + " " + Settings.SERVER_ID + " " + Settings.SECRET;
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