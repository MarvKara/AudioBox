using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Google.GData.Client;
using Google.GData.YouTube;
using Google.YouTube;

namespace Audiobox_Server.Modules.Youtube.YoutubeDownloader
{
    /// <summary>
    /// Represents a collection of search results from the Youtube Data API
    /// #######################################################
    /// Copyright: Reinier Weerts, Stenden Hogeschool 2013
    /// </summary>
    public class YoutubeSearch
    {
        private string searchString;
        private List<SearchResult> results;
        private StringBuilder searchResult;
        private int page;
        private Uri videoEntryUrl;
 
        //TODO: 
        //make developerkey a global setting
        string myDeveloperKey = "AIzaSyDi0I18MfujgHEmz30OOK3Vxc4SKfLwTMQ"; 

        public YoutubeSearch(string query, int page)
        {
            searchResult = new StringBuilder();
            searchString = query;
            this.page = page;
            results = new List<SearchResult>();
        }

        public string GetResults()
        {
            Search();
            var json = new JavaScriptSerializer().Serialize(results);
            return json;
            
        }

        private void Search()
        {
            YouTubeService myservice = new YouTubeService("aa", myDeveloperKey);
            FeedQuery fq = new FeedQuery();
            if (page == 0)
            {
                videoEntryUrl = new Uri("http://gdata.youtube.com/feeds/api/videos?q=" + searchString + "&safeSearch=none&orderby=viewCount&max-results=10");
            }
            else
            {
                page = (page * 10) + 1;
                videoEntryUrl = new Uri("http://gdata.youtube.com/feeds/api/videos?q=" + searchString + "&safeSearch=none&orderby=viewCount&max-results=10&start-index=" + page);
            }
            
            fq.Uri = videoEntryUrl;
            Feed<Video> videoFeed = new Feed<Video>(myservice, fq);

            foreach (Video entry in videoFeed.Entries)
            {
                results.Add(new SearchResult(entry.VideoId,
                                             entry.Title,
                                             entry.Thumbnails.First(),
                                             entry.ViewCount));
            }
        }
    }
}