using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using Crowdsound_Master_Server_Application.Modules.Reporting;
using Crowdsound_Master_Server_Application.Modules.ConnectionInterface;
using Crowdsound_Master_Server_Application.Modules.Database;

namespace Crowdsound_Master_Server_Application.Modules.ServerManagement
{
    public class ServerManager
    {
        public delegate void ServerListUpdateHandler(List<SlaveServer> servers);
        public event ServerListUpdateHandler ServerListUpdate;

        private Thread serverManagerThread;
        private DateTime lastUpdateTime;

        public List<SlaveServer> Servers { get; set; }
        private List<ServerConnection> PendingConnections { get; set; }

        public void OnServerListUpdate(List<SlaveServer> servers)
        {
            if (ServerListUpdate != null)
            {
                lastUpdateTime = DateTime.Now;
                ServerListUpdate(servers);
            }
        }

        public void Initialize()
        {
            List<ServerInstance> databaseServers = DBAccess.LoadServers();
            this.Servers = new List<SlaveServer>();

            foreach (ServerInstance instance in databaseServers)
            {
                this.Servers.Add(new SlaveServer(instance));
            }

            this.PendingConnections = new List<ServerConnection>();

            serverManagerThread = new Thread(ManagerMethod);
            serverManagerThread.IsBackground = true;
            serverManagerThread.Start();
        }

        private void ManagerMethod()
        {
            while(true)
            {
                Thread.Sleep(100);

                CheckServerConnectionOnlineStatuses();

                if ((DateTime.Now - lastUpdateTime).TotalMilliseconds > 2500)
                {
                    OnServerListUpdate(this.Servers);
                }
            }
        }

        private void CheckServerConnectionOnlineStatuses()
        {
            foreach(SlaveServer slaveServer in this.Servers)
            {
                if (!slaveServer.IsConnected())
                {
                    slaveServer.SetOffline();
                }
            }
        }

        public string AddServer(ServerConnection connection, string secret)
        {
            string ipAddress = connection.GetIpAddress();
            string serverId = GenerateServerId(new GeoLocation(ipAddress));
            connection.Bind(serverId);
            SlaveServer server = new SlaveServer(ipAddress, serverId, secret);
            this.Servers.Add(server);

            ConsoleHelper.PrintNewServerCreated(ipAddress, serverId);
            OnServerListUpdate(this.Servers);
            return serverId;
        }

        public string QueueConnectionForAuthentification(ServerConnection connection)
        {
            string temporaryId = GenerateAuthentificationId();
            PendingConnections.Add(connection);
            ConsoleHelper.PrintServerListedForAuthentification(temporaryId, connection.GetIpAddress());
            return temporaryId;
        }

        public string AuthentificateServer(string temporyId, string supposedId, string secret)
        {
            ServerConnection sConnection;
            if (supposedId == "NONE")
            { 
                sConnection = PendingConnections.Find(delegate(ServerConnection connection) { return connection.CoherentServerID == temporyId; });
                string newSecret = GenerateNewSecret();
                string serverId = AddServer(sConnection, newSecret);
                return serverId + "$" + newSecret;
            }
            else
            {
                foreach (SlaveServer existingServer in this.Servers)
                {
                    if (existingServer.GetServerInstanceId() == supposedId)
                    {
                        sConnection = PendingConnections.Find(delegate(ServerConnection connection) { return connection.CoherentServerID == supposedId; });

                        if (sConnection == null)
                        {
                            sConnection = PendingConnections.Find(delegate(ServerConnection connection) { return connection.CoherentServerID == temporyId; });
                            sConnection.Bind(supposedId);
                        }
                        if (existingServer.SecretMatches(secret))
                        {
                            existingServer.SetOnline(sConnection);
                            sConnection.Mute();
                            PendingConnections.Remove(PendingConnections.Find(delegate(ServerConnection connection) { return connection.CoherentServerID == supposedId; }));
                            ConsoleHelper.PrintServerConEstablished(sConnection.GetIpAddress(), existingServer.GetServerInstanceId());
                            return "CONNECTION ESTABLISHED";
                        }
                        else
                        {
                            return "WRONG CREDENTIALS PROVIDED";
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                return "CRITICAL ERROR. REPORT TO ADMINISTRATOR";
            }
        }

        private string GenerateNewSecret()
        {
            string secret = string.Empty;
            for (int i = 0; i < 111; i++)
            {
                secret += General.Actions.GenerateRandomChar();
            }
            return secret;
        }

        public string GenerateServerId(GeoLocation geoLocation)
        {
            string abbreviation = geoLocation.CountryCode;
            string index = GetNextCountrySpecificIndex(geoLocation.Country);
            string serverId = abbreviation + "-" + index;
            return serverId;
        }

        public string GenerateAuthentificationId()
        {
            return "AUTH" + (PendingConnections.Count + 1);
        }

        public List<ServerInstance> ExtractServerInstances()
        {
            List<ServerInstance> instances = new List<ServerInstance>();
            foreach (SlaveServer ss in this.Servers)
            {
                instances.Add(ss.ExtractInstance());
            }
            return instances;
        }

        private string GetNextCountrySpecificIndex(string country)
        {
            int count = 0;
            foreach (SlaveServer server in this.Servers)
            {
                if (server.GetGeoLocation().Country == country)
                {
                    count++;
                }
            }

            string index = string.Empty;

            if (count.ToString().Length == 1)
            {
                index = "0" + (count + 1).ToString();
            }
            else
            {
                index = (count + 1).ToString();
            }
            return index;
        }

        public List<SlaveServer> GetServerList()
        {
            return this.Servers;
        }
    }
}
