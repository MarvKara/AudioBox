using Audiobox_Server.Modules.UserManagement;
using Audiobox_Server.Modules.Youtube.YoutubeDownloader;
namespace Audiobox_Server.Modules.CommandInterface.Commands
{
    /// <summary>
    /// Command / ICommand-Object for Command YOUTUBESEARCH
    /// Parameter1 :: USERID
    /// Parameter2 :: QUERY
    /// Parameter3 :: PAGE
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class YOUTUBESEARCH : Command, ICommand
    {
        public static readonly bool HAS_PARAMETERS = true;
        public static readonly int NEEDS_PARAMETERS = 3;
        public static readonly UserAuthorization REQUIRED_AUTHORIZATION = UserAuthorization.Assigned;

        public YOUTUBESEARCH(string keyword, string[] parameters, UserAuthorization userAuthorization)
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
            YoutubeSearch sr = new YoutubeSearch(this.Parameters[1], int.Parse(this.Parameters[2]));
            return sr.GetResults();
        }
    }
}
