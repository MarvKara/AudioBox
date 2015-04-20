using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Audiobox_Server.General;
using Audiobox_Server.Modules.SessionManagement.Objects;
using Audiobox_Server.Modules.SessionManagement;
using Audiobox_Server.Modules.UserManagement;

namespace Audiobox_Server.Modules.AudioboxConsole
{
    /// <summary>
    /// Static class for interpreting commands. Contains most of the Command Execution logic  
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class ConsoleCommandExecutor
    {
        /// <summary>
        /// Executes any given command if known to the parser
        /// </summary>
        /// <param name="cmd"></param>
        public static string ExecuteCommand(ConsoleCommand cmd)
        {
            string param1 = cmd.Parameters[0];
            string param2 = cmd.Parameters[1];
            string param3 = cmd.Parameters[2];
            string command = cmd.CommandWord;
            string parserMessage = string.Empty;

            if (!Parser.CanInterpret(cmd, out parserMessage))
            {
                LogConsole.WriteLine("ERROR WHILE PARSING COMMAND: " + command + " ::: INVALID");
                LogConsole.Break();
                return "PARSER_ERROR";
            }

            UserAuthorization userAuthorization = UserAuthorization.None;
            UserAuthorization requiredAuthorization = ConsoleCommandWords.FindCommand(command).RequiredAuthorization;

            if (requiredAuthorization != UserAuthorization.None)
            {
                userAuthorization = UserManager.GetUserAuthorization(param1);

                if (userAuthorization != requiredAuthorization)
                {
                    LogConsole.WriteLine(UserManager.GetUserAuthorizationErrorMessage(requiredAuthorization, userAuthorization, param1));
                    LogConsole.Break();
                    return "UNAUTHORIZED";
                }
            }

            switch (command)
            {
                case "terminate":
                    {
                        LogConsole.PrintCommand(cmd);
                        Actions.TerminateServer();
                        return string.Empty;
                    }

                case "clear":
                    {
                        LogConsole.PrintCommand(cmd);
                        LogConsole.Clear();
                        return string.Empty;
                    }

                case "help":
                    {
                        LogConsole.PrintCommand(cmd);
                        LogConsole.Break();
                        LogConsole.Write(ConsoleCommandWords.CommandList());
                        return string.Empty;
                    }
                case "add":
                    {
                        LogConsole.PrintCommand(cmd);
                        LogConsole.Break();

                        switch (param1)
                        {
                            case "session":
                                {
                                    LogConsole.Break();
                                    Session newSession = new Session();
                                    SessionManager.AddSession(newSession, string.Empty, false);
                                    LogConsole.Write(newSession.Details());
                                    return newSession.Id;
                                }
                            default:
                                {
                                    LogConsole.Break();
                                    LogConsole.ThrowParseError("Invalid Type", param1);
                                    return string.Empty;
                                }
                        }
                    }
                    /// DEPRECATED
                //case "select":
                //    {
                //        LogConsole.PrintCommand(cmd);
                //        LogConsole.Break();
                //        switch (param1)
                //        {
                //            case "session":
                //                {
                //                    if (LogConsole.SelectSession(param2, SessionManager.Sessions) != false)
                //                    {
                //                        LogConsole.Break();
                //                        LogConsole.Write("Selected session is now " + param2.ToUpper());
                //                        SessionManager.OnSelectedSessionChanged();
                //                    }
                //                    else
                //                    {
                //                        LogConsole.Break();
                //                        LogConsole.ThrowParseError("Unknown Session!", param2.ToUpper());
                //                    }
                //                    return string.Empty;
                //                }
                //            default:
                //                {
                //                    LogConsole.Break();
                //                    LogConsole.ThrowParseError("Invalid Type", param1);
                //                    return string.Empty;
                //                }
                //        }
                //    }
                case "selected":
                    {
                        LogConsole.PrintCommand(cmd);
                        LogConsole.Break();

                        if (LogConsole.currentSession == null)
                        {
                            LogConsole.Write("No selected session");
                        }
                        else
                        {
                            LogConsole.Write("Selected session is " + LogConsole.currentSession.Id);
                        }
                        return string.Empty;
                    }
                case "stop":
                    {
                        switch (param1)
                        {
                            case "session":
                                {
                                    LogConsole.Break();
                                    if (SessionManager.SessionExists(param2))
                                    {
                                        SessionManager.FindSessionBySessionId(param2).Stop();
                                        LogConsole.Write("Stopped Session " + param2);
                                    }
                                    else
                                    {
                                        LogConsole.ThrowParseError("unknown " + param1 + " : " + param2 + " - Session does not exist", cmd.CommandWord);
                                    }
                                    return string.Empty;
                                }
                            default:
                                {
                                    LogConsole.Break();
                                    LogConsole.ThrowParseError("Invalid Type", param1);
                                    return string.Empty;
                                }
                        }
                    }
                case "delete":
                    {
                        switch (param1)
                        {
                            case "session":
                                {
                                    LogConsole.Break();
                                    if (SessionManager.SessionExists(param2))
                                    {
                                        if (SessionManager.FindSessionBySessionId(param2).isStopped)
                                        {
                                            SessionManager.FindSessionBySessionId(param2).Terminate();
                                            SessionManager.DeleteSession(param2);
                                            LogConsole.Write("Deleted Session " + param2);
                                        }
                                        else
                                        {
                                            LogConsole.ThrowException(SessionManager.FindSessionBySessionId(param2).Id, "Session is still running! Session must be stopped before termination");
                                        }
                                        return string.Empty;
                                    }
                                    else
                                    {
                                        LogConsole.ThrowParseError("unknown " + param1 + " : " + param2 + " - Session does not exist", cmd.CommandWord);
                                    }
                                    return string.Empty;
                                }
                            default:
                                {
                                    LogConsole.Break();
                                    LogConsole.ThrowParseError("Invalid Type", param1);
                                    return string.Empty;
                                }
                        }
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }
    }
}