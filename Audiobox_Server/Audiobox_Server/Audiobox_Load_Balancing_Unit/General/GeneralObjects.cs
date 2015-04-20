using System;

namespace Crowdsound_Master_Server_Application.General
{
    /// <summary>
    /// Static Class for general objects which can be used all over the application
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public static class GeneralObjects
    {
        public static Random random = new Random(DateTime.Now.Millisecond);
    }
}
