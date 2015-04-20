using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Audiobox_Server.Modules.UserManagement;

namespace Audiobox_Server.Modules.AudioboxConsole
{
    /// <summary>
    /// Contains all valid LogConsole Commands
    /// NEW LogConsole COMMANDS MUST BE ADDED HERE
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class ConsoleCommandWords
    {
        private static string[] validCommands = { "help", "terminate", "clear", "shrink", "enlarge", "add", "select", "selected", "stop", "delete"};

        public static List<ConsoleCommand> commands = new List<ConsoleCommand>();

        /// <summary>
        /// Creates all possible LogConsole Commands with their coherent parameters
        /// NEW LogConsole COMMANDS MUST BE ADDED HERE TOO
        /// </summary>
        public static void Initialize()
        {
            //////// LogConsole COMMANDS /////////////////LogConsole COMMANDS ///////////////////////////////////////////////
            ConsoleCommand cmd1 = new ConsoleCommand("help", new string[]{"","",""}, false, 0, UserAuthorization.None);
            ConsoleCommand cmd2 = new ConsoleCommand("terminate", new string[] { "", "", "" }, false, 0, UserAuthorization.None);
            ConsoleCommand cmd3 = new ConsoleCommand("clear", new string[] { "", "", "" }, false, 0, UserAuthorization.None);
            ConsoleCommand cmd4 = new ConsoleCommand("add", new string[] { "type", "", "" }, true, 1, UserAuthorization.None);
            ConsoleCommand cmd5 = new ConsoleCommand("select", new string[] { "type", "identifier", "" }, true, 2, UserAuthorization.None);
            ConsoleCommand cmd6 = new ConsoleCommand("selected", new string[] { "", "", "" }, false, 0, UserAuthorization.None);
            ConsoleCommand cmd7 = new ConsoleCommand("stop", new string[] { "type", "identifier", "" }, true, 2, UserAuthorization.None);
            ConsoleCommand cmd8 = new ConsoleCommand("delete", new string[] { "type", "identifier", "" }, true, 2, UserAuthorization.None);

            // NEW LogConsole COMMANDS MUST BE ADDED HERE
            commands.AddRange(new ConsoleCommand[] { cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8 }.ToList());
        }

        /// <summary>
        /// Finds a certain Command
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public static ConsoleCommand FindCommand(string name)
        {
            foreach (ConsoleCommand command in commands)
            {
                if (command.CommandWord == name)
                {
                    return command;
                }
            }
            return null;
        }

        /// <summary>
        /// Check whether a given String is a valid command word. 
        /// return true if a given string is a valid command,
        /// false if it isn't.
        /// </summary>
        /// <param name="a String"></param>
        /// <returns></returns>
        public static bool IsCommand(string input)
        {
            for (int i = 0; i < validCommands.Length; i++)
            {
                if (validCommands[i] == input)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns a string containing all known and valid comments
        /// </summary>
        /// <returns></returns>
        public static string CommandList()
        {
            string commandList = string.Empty;
            foreach (string s in validCommands)
            {
                commandList += s + " | ";
            }
            return commandList;
        }

        public static bool IsLogConsoleCommand(string commandWord)
        {
            string[] LogConsoleCommands = 
            { 
                validCommands[0], 
                validCommands[1], 
                validCommands[2], 
                validCommands[3], 
                validCommands[4], 
                validCommands[5], 
                validCommands[6], 
                validCommands[7]
            };

            foreach (string c in LogConsoleCommands)
            {
                if (commandWord == c)
                {
                    return true;
                }
            }
            return false;
        }
    }
}