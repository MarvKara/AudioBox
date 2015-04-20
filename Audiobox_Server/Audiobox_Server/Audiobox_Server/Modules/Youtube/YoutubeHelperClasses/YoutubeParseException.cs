using System;

namespace Audiobox_Server.Modules.Youtube.YouTubeHelperClasses
{
    /// <summary>
    /// <para>
    /// The exception that is thrown when the YouTube page could not be parsed.
    /// This happens, when YouTube changes the structure of their page.
    /// </para>
    /// Please report when this exception happens at www.github.com/flagbug/YoutubeExtractor/issues
    /// </summary>
    public class YoutubeParseException : Exception
    {
        public YoutubeParseException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}