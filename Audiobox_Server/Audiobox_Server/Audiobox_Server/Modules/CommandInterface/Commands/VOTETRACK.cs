using Audiobox_Server.Modules.SessionManagement;
using Audiobox_Server.Modules.UserManagement;
namespace Audiobox_Server.Modules.CommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command VOTETRACK
    /// Parameter1 :: USERID
    /// Parameter2 :: TRACKID
    /// Parameter3 :: DIRECTION
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class VOTETRACK : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 3;
        public static readonly UserAuthorization REQUIRED_AUTHORIZATION = UserAuthorization.Assigned;

        public VOTETRACK(string keyword, string[] parameters, UserAuthorization userAuthorization)
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
            if (SessionManager.TrackExists(SessionManager.FindSessionByUserId(this.Parameters[0]), this.Parameters[1].ToLower()))
            {
                if (this.Parameters[2] == "UP")
                {
                    SessionManager.VoteTrack(this.Parameters[1], SessionManager.FindSessionByUserId(this.Parameters[0]).Id, "UP");
                }
                else
                {
                    SessionManager.VoteTrack(this.Parameters[1], SessionManager.FindSessionByUserId(this.Parameters[0]).Id, "DOWN");
                }
            }
            else
            {
                message = "ERROR";
            }
            return message;
        }
    }
}