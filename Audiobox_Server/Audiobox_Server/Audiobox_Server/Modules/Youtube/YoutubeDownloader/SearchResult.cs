using System.Text;
using Google.GData.Extensions.MediaRss;

namespace Audiobox_Server.Modules.Youtube.YoutubeDownloader
{
    /// <summary>
    /// Represents a search result from the Youtube Data API
    /// #######################################################
    /// Copyright: Reinier Weerts, Stenden Hogeschool 2013
    /// </summary>
    public class SearchResult
    {
        public string VIDEO_ID { get; set; }
        public string VIDEO_TITLE { get; set; }
        public string THUMBNAIL { get; set; }
        public int VIEWCOUNT { get; set; }

        /// <summary>
        /// Default Constructor for a SearchResult
        /// </summary>
        /// <param name="VIDEO_ID"></param>
        /// <param name="VIDEO_TITLE"></param>
        /// <param name="THUMBNAIL"></param>
        /// <param name="VIEWCOUNT"></param>
        public SearchResult(string videoID, string Title, MediaThumbnail Thumbnails, int ViewCount)
        {
            //format: BUMNgQdnSmw
            this.VIDEO_ID = videoID;
            //format: Toto IV (Full album)
            this.VIDEO_TITLE = Title;
            //format: https://i.ytimg.com/vi/BUMNgQdnSmw/default.jpg
            this.THUMBNAIL = Thumbnails.Url;
            //format: 282748
            this.VIEWCOUNT = ViewCount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(VIDEO_ID + ";" + VIDEO_TITLE + ";" + THUMBNAIL + ";" + VIEWCOUNT);
            return sb.ToString();
        }
    }
}