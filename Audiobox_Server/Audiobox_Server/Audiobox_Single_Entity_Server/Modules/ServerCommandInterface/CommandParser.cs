using Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface.Commands;

namespace Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface
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
            string[] raw = input.Split('$');
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
                case "AUTHSERVER":
                    {
                        command = new AUTHSERVER(commandWord, new string[] { parameter1});
                        break;
                    }
                case "REAUTHSERVER":
                    {
                        command = new REAUTHSERVER(commandWord, new string[] {parameter1, parameter2});
                        break;
                    }
                case "TAKEIDENT":
                    {
                        command = new TAKEIDENT(commandWord, new string[] {});
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