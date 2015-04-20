using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Audiobox_ASP.Controllers
{
    public class HomeController : Controller
    {
        private string webAddress = "http://127.0.0.1:9999";
        Logger log = new Logger();

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Method accepts POST form Data. This method filters the 
        /// incoming data for commands and sends it to the C# Server.
        /// it separates the normal commands from the commands with special treatment.
        /// </summary>
        /// <param name="formCollection">Form data send via POST</param>

        public string JansIsEenHeld(FormCollection formCollection)
        {
            string getString = "?";

            for (int i = 0; i < formCollection.Count; i++)
            {
                getString += formCollection.GetKey(i);
                getString += "=";
                getString += formCollection.Get(i);
                log.CreateEventLog("Post command recieved: " + formCollection.Get(i));
                if ((i + 1) != formCollection.Count)
                {
                    getString += "&";
                }
            }
            return SendCommand(getString).ToString();
        }

        /// <summary>
        /// This method sends the commandString to the specified server address and will recieve a response.
        /// If something went wrong this command returns a HttpStatusCode.
        /// </summary>
        /// <param name="commandString"></param>
        private String SendCommand(String commandString)
        {
            string content = "";
            log.CreateEventLog("sending: " + commandString + " to server.");
            using (WebClient client = new WebClient { Encoding = Encoding.UTF8 })
            {
                try
                {
                    content = client.DownloadString(webAddress + commandString);
                    log.CreateEventLog("Recieved response from server: " + content);
                }
                catch (WebException e)
                {
                    using (WebResponse response = e.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        log.CreateEventLog("Exception triggered, statuscode: " + httpResponse.StatusCode);
                        Response.StatusCode = Convert.ToInt32(httpResponse.StatusCode);
                        Response.StatusDescription = httpResponse.StatusDescription;
                        return "ASP failed to retrieve a response from the server";
                    }
                }
            }
            log.CreateEventLog("sending string back to Android: " + content);

            if (content == "")
            {
                return "empty";
            }
            else
            {
                return content;
            }
        }
    }
}
