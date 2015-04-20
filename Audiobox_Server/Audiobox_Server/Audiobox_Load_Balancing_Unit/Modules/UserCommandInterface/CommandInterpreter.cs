using System.Collections.Generic;
using System.Threading;

namespace Crowdsound_Master_Server_Application.Modules.CommandInterface
{
    /// <summary>
    /// New CommandInterpreter Class which interprets request send to the TCP-Socket and executes 
    /// Commands depending on input on a collection of GET-parameters. 
    /// [NEW VERSION WITH ICommand]
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class CommandInterpreter
    {
        private static Thread listener;
        private Queue<ICommand> cmdQueue;

        /// <summary>
        /// Standard Constructor
        /// </summary>
        public CommandInterpreter()
        {
            cmdQueue = new Queue<ICommand>();
            this.Start();
        }

        /// <summary>
        /// Start-Method for the Command-Interpreter
        /// </summary>
        private void Start()
        {
            listener = new Thread(ListenerMethod);
            listener.IsBackground = true;
            listener.Start();
        }

        /// <summary>
        /// The threadmethod for the Command-Interpreter
        /// </summary>
        private void ListenerMethod()
        {
            while (true)
            {

            }
        }

        /// <summary>
        /// Method which filters the command and parameters in get-form to a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string FilterCommandString(string input)
        {
            return input.Substring(22);
        }
    }
}