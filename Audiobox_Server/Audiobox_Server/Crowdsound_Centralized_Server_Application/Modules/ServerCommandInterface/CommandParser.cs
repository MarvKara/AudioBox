namespace Crowdsound_Centralized_Server_Application.Modules.ServerCommandInterface
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
            var raw = input.Split(' ');
            var numberOfParameters = raw.Length - 1;
            string commandWord;
            var parameter1 = string.Empty;
            var parameter2 = string.Empty;
            var parameter3 = string.Empty;
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
                default:
                    {
                        return null;
                    }
            }
        }
    }
}