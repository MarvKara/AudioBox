using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace Crowdsound_Master_Server_Application.Modules.ServerManagement
{
    [Serializable]
    public class GeoLocation
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

        public GeoLocation(string ipAdress)
        {
            try
            {
                var request = WebRequest.Create(new Uri("http://freegeoip.net/xml/" + ipAdress)) as HttpWebRequest;

                if (request != null)
                {
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727)";

                    using (var webResponse = (request.GetResponse() as HttpWebResponse))
                    {
                        if (webResponse != null)
                        {
                            using (var reader = new StreamReader(webResponse.GetResponseStream()))
                            {
                                var doc = new XmlDocument();
                                doc.Load(reader);

                                var nodes = doc.GetElementsByTagName("Response");

                                this.City = nodes[0].ChildNodes[5].InnerText;
                                this.Country = nodes[0].ChildNodes[2].InnerText;
                                this.CountryCode = nodes[0].ChildNodes[1].InnerText;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error: Check Connnection! --> Service Unavailable");
                this.Country = "UNKNOWN";
                this.CountryCode = "XX";
            }
        }
    }
}