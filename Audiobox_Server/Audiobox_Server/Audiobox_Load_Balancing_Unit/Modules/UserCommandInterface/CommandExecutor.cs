//----------------------------------------------------------------------------------//
//------------------            _____ _____  ---------------------------------------//
//------------------     /\    / ____|  __ \   ----------INTERFACE------------------//
//------------------    /  \  | (___ | |__)    -------------------------------------//
//------------------   / /\ \  \___ \|  ___/  -----------------COMMANDS-------------//
//------------------  / ____ \ ____) | |     ---------------------------------------//
//------------------ /_/    \_\_____/|_|     ---------------------------------------//
//----------------------------------------------------------------------------------//

namespace Crowdsound_Master_Server_Application.Modules.CommandInterface
{
    /// <summary>
    /// Static Command-Executor Class. Used to Execute given ICommand objects.
    /// #######################################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class CommandExecutor
    {
        /// <summary>
        /// The Execution-Method
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string ExecuteCommand(ICommand command)
        {
            var message = string.Empty;

            if (command.IsAuthorized())
            {
                message = command.Execute();
            }
            else
            {
                message = "UNAUTHORIZED";
            }
            return message;
        }
    }
}
