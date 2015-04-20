using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Audiobox_Server.Modules.UserManagement;

namespace Audiobox_Server.Modules.AudioboxConsole
{
    /// <summary>
    /// Command-Class // Represents a Command-Object 
    ///               // ONLY USED FOR LogConsole COMMANDS
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public class ConsoleCommand
    {
        public string CommandWord { get; set; }
        public string[] Parameters { get; set; }
        public int NeedsParameters { get; set; }
        public bool HasParameters { get; set; }
        public UserAuthorization RequiredAuthorization { get; set; }
        
        /// <summary>
        /// Empty Constructor for standardized operations
        /// </summary>
        public ConsoleCommand()
        {
            this.CommandWord = null;
            this.Parameters = new string[3];
            RequiredAuthorization = UserAuthorization.None;
        }

        /// <summary>
        /// Constructor for Commands without parameters
        /// </summary>
        public ConsoleCommand(string keyword)
        {
            this.CommandWord = keyword;
            this.Parameters = new string[3];
            RequiredAuthorization = UserAuthorization.None;
        }

        /// <summary>
        /// Constructor for Commands with Parameters
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="parameters"></param>
        public ConsoleCommand(string keyword, string[] parameters)
        {
            this.CommandWord = keyword;
            this.Parameters = parameters;
            RequiredAuthorization = UserAuthorization.None;
        }

        /// <summary>
        /// Full Constructor with all options
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="parameters"></param>
        /// <param name="hasParam"></param>
        /// <param name="needsParam"></param>
        public ConsoleCommand(string keyword, string[] parameters, bool hasParam, int needsParam, UserAuthorization requiredAuthorization)
        {
            this.CommandWord = keyword;
            this.Parameters = parameters;
            this.HasParameters = hasParam;
            this.NeedsParameters = needsParam;
            RequiredAuthorization = requiredAuthorization;
        }

        /// <summary>
        /// Return true if this command was not understood.
        /// </summary>
        /// <returns></returns>
        public bool IsUnknown()
        {
            return (this.CommandWord == null);
        }

        /// <summary>
        /// Validates if a command has the right amount of parameters
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool Matches(ConsoleCommand cmd, out string msg)
        {
            if (this.HasParameters == true && this.NeedsParameters == 1)
            {
                if (cmd.Parameters[0] == string.Empty)
                {
                    msg = "missing single parameter ";
                    return false;
                }
            }
            if (this.HasParameters == true && this.NeedsParameters == 2)
            {
                if (cmd.Parameters[0] == string.Empty || cmd.Parameters[1] == string.Empty)
                {
                    msg = "missing one or more parameters ";
                    return false;
                }
            }
            if (this.HasParameters == false)
            {
                if (cmd.Parameters[0] != string.Empty || cmd.Parameters[1] != string.Empty)
                {
                    msg = "redundant parameter. command does not need parameters";
                    return false;
                }
                else
                {
                    msg = "";
                    return true;
                }
            }
            else
            {
                msg = "";
                return true;
            }
        }

        public bool MeetsRequiredAuthorization(UserAuthorization userAuthorization)
        {
            if (userAuthorization == this.RequiredAuthorization)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the a string which represents a command with all of its parameters
        /// </summary>
        /// <returns></returns>
        public string ConvertToString()
        {
            string output = string.Empty;

            output += this.CommandWord;

            if (this.Parameters != null)
            {
                foreach (string s in this.Parameters)
                {
                    output += " " + s;
                }
            }

            return output;
        }

        public static ConsoleCommand Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length == 1)
            {
                return new ConsoleCommand(parts[0]);
            }
            if (parts.Length == 2)
            {
                return new ConsoleCommand(parts[0], new string[] { parts[1], "", ""});
            }
            if (parts.Length == 3)
            {
                return new ConsoleCommand(parts[0], new string[] { parts[1], parts[2], ""});
            }
            if (parts.Length == 4)
            {
                return new ConsoleCommand(parts[0], new string[] { parts[1], parts[2], parts[3] });
            }
            return null;
        }

        public static string CleanupGetString(string input)
        {
            input = input.Replace('?',' ');
            input = input.Replace('&', ' ');
            input = input.Replace('=', ' ');
            return input.Remove(0,1);
        }

        public static string ReformatCommandString(string input)
        {
            string[] raw = input.Split(' ');
            string result = "";

            for (int i = 0; i < raw.Length; i++)
            {
                if (i != 1 && i != 3 && i != 5 && i != 7 && i != 9)
                {
                    result += raw[i + 1] + " ";
                }
            }
            return result.Remove((result.Length - 1), 1);
        }
    }
}