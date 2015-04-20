using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdsound_Master_Server_Application.Modules.ConnectionInterface;
using System.Windows.Forms;

namespace Crowdsound_Master_Server_Application.Modules.ServerManagement
{
    public class SlaveServer
    {
        private ServerInstance ServerInstance { get; set; }
        private ServerConnection ServerConnection { get; set; }

        public SlaveServer(ServerConnection connection, string id, string secret)
        {
            this.ServerInstance = new ServerInstance(connection.GetIpAddress(), id);
            this.ServerInstance.Secret = secret;
            this.ServerConnection = connection;
        }

        public SlaveServer(string ip, string id, string secret)
        {
            this.ServerInstance = new ServerInstance(ip, id);
            this.ServerInstance.Secret = secret;
        }

        public SlaveServer(ServerInstance instance)
        {
            this.ServerInstance = instance;
            this.ServerConnection = null;
        }

        public string GetServerInstanceId()
        {
            return this.ServerInstance.ID;
        }

        public GeoLocation GetGeoLocation()
        {
            return this.ServerInstance.GeoLocation;
        }

        public bool SecretMatches(string input)
        {
            if (String.Equals(this.ServerInstance.Secret, input, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsConnected()
        {
            try
            {
                return this.ServerConnection.IsAlive();
            }
            catch
            {
                return false;
            }
        }

        public void SetOnline(ServerConnection connection)
        {
            ServerInstance.SetStatusOnline();
            ServerConnection = connection;
        }

        public void SetOffline()
        {
            ServerInstance.SetStatusOffline();
            ServerConnection = null;
        }

        public void GetConnection(out ServerConnection sConnection)
        {
            sConnection = this.ServerConnection;
        }

        public ServerInstance ExtractInstance()
        {
            return this.ServerInstance;
        }

        public ListViewItem ConvertToListViewItem()
        {
            return this.ServerInstance.ConvertToListViewItem();
        }
    }
}
