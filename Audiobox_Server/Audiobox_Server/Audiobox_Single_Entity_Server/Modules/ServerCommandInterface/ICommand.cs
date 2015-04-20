namespace Crowdsound_Slave_Server_Application.Modules.ServerCommandInterface
{
    /// <summary>
    /// The ICommand Interface. Gives rules about which methods need to be implemented
    /// ##############################################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public interface ICommand
    {
        bool IsCorrectFormat(int parameters);
        string Execute();
    }
}