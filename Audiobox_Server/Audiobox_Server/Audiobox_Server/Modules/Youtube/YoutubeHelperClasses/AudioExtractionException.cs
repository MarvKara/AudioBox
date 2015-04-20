using System;

namespace Audiobox_Server.Modules.Youtube.YouTubeHelperClasses
{
    /// <summary>
    /// The exception that is thrown when an error occurs durin audio extraction.
    /// </summary>
    public class AudioExtractionException : Exception
    {
        public AudioExtractionException(string message)
            : base(message)
        { }
    }
}