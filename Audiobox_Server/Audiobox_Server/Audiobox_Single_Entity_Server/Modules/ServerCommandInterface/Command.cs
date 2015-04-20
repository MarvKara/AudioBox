using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface
{
    /// <summary>
    /// Abstract Command Class for GET-formatted commands
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public abstract class Command
    {
        public string CommandWord { get; protected set; }
        public string[] Parameters { get; protected set; }

        /// <summary>
        /// Standard Contructor
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="parameters"></param>
        public Command(string keyword, string[] parameters)
        {
            this.CommandWord = keyword;
            this.Parameters = parameters;
        }

        /// <summary>
        /// Static method which evaluates with a given combination of parameters if 
        /// a command may pass the parser or throw an error
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="needsParameters"></param>
        /// <param name="hasParameters"></param>
        /// <returns></returns>
        protected static bool HasCorrectFormat(int parameters, int needsParameters, bool hasParameters)
        {
            if (hasParameters && parameters > 0)
            {
                if (parameters == needsParameters)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (!hasParameters)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns the a string which represents a command with all of its parameters
        /// </summary>
        /// <returns></returns>
        public override string ToString()
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

        /// <summary>
        /// Cleans all GET-related signs from an inputted string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CleanupGetString(string input)
        {
            input = input.Replace('?', ' ');
            input = input.Replace('&', ' ');
            input = input.Replace('=', ' ');
            return input.Remove(0, 1);
        }

        /// <summary>
        /// Reformats a given string to make is readable through the parser
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ReformatCommandString(string input)
        {
            string[] raw = input.Split(' ');

            if (input.Contains("QUERY"))
            {
                int startIndex = 0;
                int endIndex = 0;
                int count = 0;
                foreach (string part in raw)
                {
                    if (part == "QUERY")
                    {
                        startIndex = count + 1;
                    }
                    if (part == "PAGE")
                    {
                        endIndex = count - 1;
                    }
                    count++;
                }

                string[] cleanedRaw = new string[8];
                string completeQuery = string.Empty;
                int offset = 0;
                bool read = false;
                for (int i = 0; i < raw.Length; i++)
                {
                    if (read == true)
                    {
                        completeQuery += raw[i];
                        offset++;
                    }
                    if (i == startIndex)
                    {
                        read = true;
                        completeQuery += raw[i];
                    }
                    if (i == endIndex)
                    {
                        read = false;
                    }
                }

                cleanedRaw[0] = raw[0];
                cleanedRaw[1] = raw[1];
                cleanedRaw[2] = raw[2];
                cleanedRaw[3] = raw[3];
                cleanedRaw[4] = raw[4];
                cleanedRaw[5] = completeQuery;
                cleanedRaw[6] = raw[6 + offset];
                cleanedRaw[7] = raw[7 + offset];

                raw = new string[8];
                cleanedRaw.CopyTo(raw, 0);
            }

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