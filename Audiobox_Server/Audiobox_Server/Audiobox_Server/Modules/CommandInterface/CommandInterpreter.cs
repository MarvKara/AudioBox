using System.Collections.Generic;
using System.Net;
using System.Threading;
using Audiobox_Server.General;
using Audiobox_Server.Modules.AudioboxConsole;

//----------------------------------------------------------------------------------//
//------------------            _____ _____  ---------------------------------------//
//------------------     /\    / ____|  __ \   ----------INTERFACE------------------//
//------------------    /  \  | (___ | |__)    -------------------------------------//
//------------------   / /\ \  \___ \|  ___/  -----------------COMMANDS-------------//
//------------------  / ____ \ ____) | |     ---------------------------------------//
//------------------ /_/    \_\_____/|_|     ---------------------------------------//
//----------------------------------------------------------------------------------//

namespace Audiobox_Server.Modules.CommandInterface
{
    /// <summary>
    /// New CommandInterpreter Class which interprets HTTP-Requests and executes 
    /// Commands depending on input on a collection of GET-parameters. 
    /// [NEW VERSION WITH ICommand]
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class CommandInterpreter
    {
        private static Thread listener;
        private Queue<ICommand> cmdQueue;
        private HttpListener commandListener;

        /// <summary>
        /// Standard Constructor
        /// </summary>
        public CommandInterpreter()
        {
            commandListener = new HttpListener();
            commandListener.Prefixes.Add(Actions.BuildCommandListenerUrlString('l'));
            cmdQueue = new Queue<ICommand>();
            this.Start();
        }

        /// <summary>
        /// Start-Method for the Command-Interpreter
        /// </summary>
        private void Start()
        {
            commandListener.Start();

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
                HttpListenerContext output;
                try
                {
                    output = commandListener.GetContext();
                }
                catch
                {
                    break;
                }
                var response = output.Response;

                string sourceString = FilterCommandString(output.Request.Url.ToString());
                string message = string.Empty;

                if (!ConsoleCommandWords.IsLogConsoleCommand(sourceString))
                {
                    string cleanSourceString = Command.CleanupGetString(sourceString);
                    string command = string.Empty;
                    try
                    {
                        command = Command.ReformatCommandString(cleanSourceString);
                        ICommand parsedCommand = CommandParser.Parse(command);
                        if (parsedCommand == null)
                        {
                            message = "PARSER_ERROR";
                            LogConsole.ThrowParseError("PARSER_ERROR", sourceString);
                        }
                        else
                        {
                            cmdQueue.Enqueue(parsedCommand);
                            message = CommandExecutor.ExecuteCommand(cmdQueue.Dequeue());
                        }
                    }
                    catch
                    {
                        message = "PARSER_ERROR";
                        LogConsole.ThrowParseError("PARSER_ERROR", sourceString);
                    }
                }
                else
                {
                    message = "FORBIDDEN";
                    LogConsole.ThrowParseError("FORBIDDEN", sourceString);
                }
                response.ContentType = new System.Net.Mime.ContentType("text/plain").ToString();
                response.StatusCode = Actions.ResolveToHttpStatusCode(message);

                byte[] byteCode = System.Text.Encoding.UTF8.GetBytes(message);
                response.OutputStream.Write(byteCode, 0, byteCode.Length);
                response.OutputStream.Flush();
                response.OutputStream.Close();
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