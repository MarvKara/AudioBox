using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Audiobox_Server.Modules.AudioboxConsole
{
    /// <summary>
    /// Parser class which is used to parse the strings given to the commandline
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Checks if a given keyword is valid command and saves his given parameters
        /// </summary>
        /// <param name="commandLine"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool CanRead(string commandLine, out ConsoleCommand cmd)
        {
            string keyword = commandLine.Split(' ')[0];
            string param1;
            string param2;

            try
            {
                param1 = commandLine.Split(' ')[1];
            }
            catch
            {
                param1 = string.Empty;
            }

            try
            {
                param2 = commandLine.Split(' ')[2];
            }
            catch
            {
                param2 = string.Empty;
            }

            if (keyword != string.Empty)
            {
                if (ConsoleCommandWords.IsCommand(keyword))
                {
                    cmd = new ConsoleCommand(keyword);
                    cmd.Parameters[0] = param1;
                    cmd.Parameters[1] = param2;
                    return true;
                }
                else
                {
                    cmd = new ConsoleCommand(commandLine);
                    return false;
                }
            }
            else
            {
                cmd = new ConsoleCommand(commandLine);
                return false;
            }
        }

        /// <summary>
        /// Validates if a command has the right amount of parameters
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool CanInterpret(ConsoleCommand cmd, out string parserMsg)
        {
            string msg = string.Empty;
            ConsoleCommand validVersion = ConsoleCommandWords.FindCommand(cmd.CommandWord);
            if (validVersion.Matches(cmd, out msg))
            {
                parserMsg = msg;
                return true;
            }
            else
            {
                parserMsg = msg;
                return false;
            }
        }
    }
}
