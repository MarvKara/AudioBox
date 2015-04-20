using System;

namespace Audiobox_Server.General
{
    /// <summary>
    /// Static Class for general objects which can be used all over the application
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    public static class GeneralObjects
    {
        public static Random random = new Random(DateTime.Now.Millisecond);
        public const string SESSION_FOLDERNAME = "_SESSIONS";
    }
}
