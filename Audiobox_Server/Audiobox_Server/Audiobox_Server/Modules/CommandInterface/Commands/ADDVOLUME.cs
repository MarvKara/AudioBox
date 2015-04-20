using Audiobox_Server.Modules.SessionManagement;
using Audiobox_Server.Modules.UserManagement;
using System.Windows.Forms;
namespace Audiobox_Server.Modules.CommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command ADDVOLUME
    /// Parameter1 :: USERID
    /// Parameter2 :: VOLUME
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    class ADDVOLUME : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 2;
        public static readonly UserAuthorization REQUIRED_AUTHORIZATION = UserAuthorization.Assigned;

        public ADDVOLUME(string keyword, string[] parameters, UserAuthorization userAuthorization)
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

            if (int.Parse(Parameters[1]) > 0 && int.Parse(Parameters[1]) < 100)
            {
                SessionManager.FindSessionByUserId(this.Parameters[0]).VolumeManager.AddVolume(this.Parameters[0], int.Parse(Parameters[1]));
            }

            else
            {
                message = "ERROR";
            }
            
            return message;
        }
    }
}