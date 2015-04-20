using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Crowdsound_Master_Server_Application.Modules.ConnectionInterface;
using Crowdsound_Master_Server_Application.Modules.Reporting;
using Crowdsound_Master_Server_Application.Modules.ServerCommandInterface;
using System.Runtime.Serialization;

namespace Crowdsound_Master_Server_Application.Modules.ServerManagement
{
    /// <summary>
    /// Class representing an individual Slave Server Entity
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    [Serializable]
    public class ServerInstance : ICloneable
    {
        public string ID { get; set; }
        public string Secret { get; set; }
        public GeoLocation GeoLocation { get; set; }
        public ServerStatus Status { get; set; }
        public string IpAdress { get; set; }
        List<string> SessionIDs { get; set; }

        /// <summary>
        /// The Standard-Constructor
        /// </summary>
        public ServerInstance(string ipAdress, string id)
        {
            this.GeoLocation = new GeoLocation(ipAdress);
            this.IpAdress = ipAdress;
            this.ID = id;
            this.SessionIDs = new List<string>();
        }

        public void RefreshServerInformation(string ipAdress, List<string> sessionIds)
        {
            this.IpAdress = ipAdress;
            this.SessionIDs = sessionIds;
        }

        public void SetStatusOnline()
        {
            this.Status = ServerStatus.Online;
        }

        public void SetStatusOffline()
        {
            this.Status = ServerStatus.Offline;
        }

        /// <summary>
        /// Returns all information about a server as a listviewitem
        /// </summary>
        /// <returns></returns>
        public ListViewItem ConvertToListViewItem()
        {
            ListViewItem newLvi = new ListViewItem(this.ID);
            newLvi.SubItems.Add(this.GeoLocation.Country);
            newLvi.SubItems.Add(this.Status.ToString());
            newLvi.SubItems.Add(this.IpAdress);
            newLvi.SubItems.Add(this.SessionIDs.Count.ToString());

            return newLvi;
        }

        public object Clone()
        {
            ServerInstance instance = (ServerInstance)this.MemberwiseClone();
            return instance;
        }
    }
}