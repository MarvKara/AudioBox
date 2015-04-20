//----------------------------------------------------------------------------------//
//------------------            _____ _____  ---------------------------------------//
//------------------     /\    / ____|  __ \   ----------INTERFACE------------------//
//------------------    /  \  | (___ | |__)    -------------------------------------//
//------------------   / /\ \  \___ \|  ___/  -----------------COMMANDS-------------//
//------------------  / ____ \ ____) | |     ---------------------------------------//
//------------------ /_/    \_\_____/|_|     ---------------------------------------//
//----------------------------------------------------------------------------------//
using Audiobox_Server.Modules.CommandInterface.Commands;
using Audiobox_Server.Modules.UserManagement;
namespace Audiobox_Server.Modules.CommandInterface
{
    /// <summary>
    /// Static CommandParser Class. Is used to parse GET-formatted string 
    /// to ICommand-Objects, which ought to be enqueued in the Command-Queue
    /// ####################################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class CommandParser
    {
        public static ICommand Parse(string input)
        {
            string[] raw = input.Split(' ');
            int numberOfParameters = raw.Length - 1;
            string commandWord;
            string parameter1 = string.Empty;
            string parameter2 = string.Empty;
            string parameter3 = string.Empty;
            ICommand command;

            if(raw[0] != null)
            {
                commandWord = raw[0];
            }
            else
            {
                return null;
            }

            switch(numberOfParameters)
            {
                case 1:
                    {
                        parameter1 = raw[1];
                        break;
                    }
                case 2:
                    {
                        parameter1 = raw[1];
                        parameter2 = raw[2];
                        break;
                    }
                case 3:
                    {
                        parameter1 = raw[1];
                        parameter2 = raw[2];
                        parameter3 = raw[3];
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }

            switch (commandWord)
            {
                case "REGUSER":
                    {
                        command = new REGUSER(commandWord, new string[] { parameter1 }, 
                            UserAuthorization.None);
                        break;
                    }
                case "REGHOST":
                    {
                        command = new REGHOST(commandWord, new string[] { parameter1}, 
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "REFRESHGID":
                    {
                        command = new REFRESHGID(commandWord, new string[] { parameter1, parameter2 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "REGCLIENT":
                    {
                        command = new REGCLIENT(commandWord, new string[] { parameter1, parameter2 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "VOTETRACK":
                    {
                        command = new VOTETRACK(commandWord, new string[] { parameter1, parameter2, parameter3 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "GETPLAYLIST":
                    {
                        command = new GETPLAYLIST(commandWord, new string[] { parameter1 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "GETPLAYLISTUPDATETIME":
                    {
                        command = new GETPLAYLISTUPDATETIME(commandWord, new string[] { parameter1 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "YOUTUBESEARCH":
                    {
                        command = new YOUTUBESEARCH(commandWord, new string[] { parameter1, parameter2, parameter3 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "ADDYOUTUBETRACK":
                    {
                        command = new ADDYOUTUBETRACK(commandWord, new string[] { parameter1, parameter2 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "ADDVOLUME":
                    {
                        command = new ADDVOLUME(commandWord, new string[] { parameter1, parameter2 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "GETVOLUME":
                    {
                        command = new GETVOLUME(commandWord, new string[] { parameter1 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "KEEPALIVE":
                    {
                        command = new KEEPALIVE(commandWord, new string[] { parameter1 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "LOGOUTUSER":
                    {
                        command = new LOGOUTUSER(commandWord, new string[] { parameter1 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "GETSESSIONID":
                    {
                        command = new GETSESSIONID(commandWord, new string[] { parameter1 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                case "DESTROYSESSION":
                    {
                        command = new DESTROYSESSION(commandWord, new string[] { parameter1 },
                            UserManager.GetUserAuthorization(parameter1));
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }

            if (command.IsCorrectFormat(numberOfParameters))
            {
                return command;
            }
            return null;
        }
    }
}