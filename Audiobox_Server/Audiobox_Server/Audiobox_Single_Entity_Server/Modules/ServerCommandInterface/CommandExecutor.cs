namespace Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface
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

            message = command.Execute();
            
            return message;
        }
    }
}
