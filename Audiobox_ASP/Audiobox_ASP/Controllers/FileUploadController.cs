using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text;

namespace Audiobox_ASP.Controllers
{
    public class FileUploadController : Controller
    {
        Logger log = new Logger();
        private string webAddress = "http://127.0.0.1:9999";
        private static string MAP_PATH = AppDomain.CurrentDomain.BaseDirectory + "_SESSIONS" + @"\";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            ViewData["message"] = "Get";
            return View();
        }

        public String Post(FormCollection collection)
        {
            string userId = collection.Get("USERID"); 

            string session = SendCommand("?COMMAND=GETSESSIONID&USERID=" + userId).ToString();
            if (session.Length == 4)
            {

                try
                {
                    HttpFileCollectionBase files = (HttpFileCollectionBase)Request.Files;

                    if (files.Count == 0)
                    {

                        return "No Files found";
                    }

                    for (int counter = 0; counter < files.Count; counter++)
                    {

                        HttpPostedFileBase file = files[counter] as HttpPostedFileBase;

                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(MAP_PATH + session + @"\", fileName);
                            log.CreateEventLog("Trying to save file to: " + MAP_PATH + session + @"\" + fileName);
                            file.SaveAs(path);
                        }
                    }
                }
                catch (Exception)
                {
                    Response.StatusCode = 410;
                    Response.StatusDescription = "File could not be saved by the server";
                    log.CreateEventLog("File could not be saved by the server");
                    return "Error";
                }

                return "File uploaded!";
            }
            else
            {
                return "incorrect session code length recieved from server";
            }
        }

        private object SendCommand(String commandString)
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
                        return 0;
                    }
                }
            }
            

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
