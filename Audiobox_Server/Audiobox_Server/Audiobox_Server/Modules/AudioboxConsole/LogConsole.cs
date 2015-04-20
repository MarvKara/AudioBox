using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Audiobox_Server.Modules.SessionManagement.Objects;

namespace Audiobox_Server.Modules.AudioboxConsole
{
    /// <summary>
    /// Static Class which represents the LogConsole-Window which is one of the primary UI-Elements
    /// and handles I/O-Interactions with a direct user
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class LogConsole
    {
        public delegate void NewLogConsoleEntryHandler(List<string> log);
        public static event NewLogConsoleEntryHandler NewEntry;

        private static List<string> log = new List<string>();
        public static Session currentSession = null;

        public static void OnNewLogConsoleEntry(List<string> logContent)
        {
            if (NewEntry != null)
            {
                NewEntry(logContent);
            }
        }

        /// <summary>
        /// Initialization // TODO: More Init-Code
        /// </summary>
        public static void Initialize()
        {
            Write("Initializing Server...");
            Break();
            RunInitializationCounter();
        }

        /// <summary>
        /// Attempts to parse the command-line entered
        /// </summary>
        /// <param name="commandLine"></param>
        public static void AttemptParsing(string commandLine)
        {
            ConsoleCommand cmd = new ConsoleCommand();
            string parserMsg = string.Empty;

            if (Parser.CanRead(commandLine, out cmd))
            {
                if (Parser.CanInterpret(cmd, out parserMsg))
                {
                    ConsoleCommandExecutor.ExecuteCommand(cmd);
                }
                else
                {
                    Break();
                    ThrowParseError(parserMsg, cmd.CommandWord);
                }
            }
            else
            {
                Break();
                ThrowParseError("Unknown command", cmd.CommandWord);
            }
        }

        public static void PrintBufferStatus(int pos, int len)
        {
            LogConsole.Write("POS: " + pos.ToString() + " / LENGTH: " + len.ToString() + "\n");
        }

        private static void CheckLogCapacityExceedation()
        {
            if (log.Count > 200)
            {
                log.RemoveAt(0);
            }
        }

        /// <summary>
        /// Basic output to LogConsole (single line)
        /// </summary>
        /// <param name="text"></param>
        public static void Write(string text)
        {
            CheckLogCapacityExceedation();
            log.Add(text);
            OnNewLogConsoleEntry(log);
        }

        /// <summary>
        /// Basic output to LogConsole (multi line)
        /// </summary>
        /// <param name="lines"></param>
        public static void Write(List<string> lines)
        {
            foreach (string s in lines)
            {
                log.Add(s+"\n");
                OnNewLogConsoleEntry(log);
            }
        }

        /// <summary>
        /// Breaks the LogConsole (\r\n)
        /// </summary>
        public static void Break()
        {
            Write("\r\n");
        }

        public static void WriteLine(string text)
        {
            Write("\r\n");
            log.Add(text);
        }

        /// <summary>
        /// Clears the LogConsole window
        /// </summary>
        public static void Clear()
        {
            log.Clear();
            OnNewLogConsoleEntry(log);
        }

        /// <summary>
        /// Print routine if a command is executed
        /// </summary>
        /// <param name="cmd"></param>
        public static void PrintCommand(ConsoleCommand cmd)
        {
            Break();
            Write("Execute command: # " + cmd.ConvertToString() + " #");
        }

        public static void RunInitializationCounter()
        {
            // Thread bauen um loading darzustellen

            Write("Completed. Please enter commands below.");
            Break();
            Write("For a list of possible commands type \"help\"");
            Break();
        }

        /// <summary>
        /// Throws an error-message if fired
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="command"></param>
        public static void ThrowParseError(string reason, string command)
        {
            Break();
            Write("Error! " + reason + " - command : " + command);
        }

        /// <summary>
        /// Throws an Exception to the LogConsole window
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="command"></param>
        public static void ThrowException(string objectName, string text)
        {
            Write("Error! Object: " + objectName + " - Message: " + text);
        }

        private static void DeleteLastLine()
        {
            List<string> lines = log;
            if (lines.Count > 0)
            {
                lines.RemoveAt(lines.Count - 1);
                log = lines;
            }
        }

        public static bool SelectSession(string sessionName, List<Session> sessions)
        {
            foreach (Session session in sessions)
            {
                if (session.Id == sessionName.ToUpper())
                {
                    currentSession = session;
                    return true;
                }
            }
            return false;
        }
    }
}
