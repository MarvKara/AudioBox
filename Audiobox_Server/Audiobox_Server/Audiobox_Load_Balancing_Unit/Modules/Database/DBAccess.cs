using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdsound_Master_Server_Application.Modules.ServerManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Crowdsound_Master_Server_Application.Modules.Database
{
    public static class DBAccess
    {
        private const string FILENAME = "servers.csdb";

        public static void Initialize()
        {
            Create();
        }

        public static void Create()
        {
            var file = new FileInfo(FILENAME);
            if (!file.Exists)
            {
                file.Create();
            }
        }

        public static List<ServerInstance> LoadServers()
        {
            try
            {
                StreamReader reader = new StreamReader(new FileInfo(FILENAME).FullName);

                List<ServerInstance> servers = new List<ServerInstance>();
                string data = string.Empty;
                while ((data = reader.ReadLine()) != null)
                {
                    servers = DeserializeFromString(data);
                }
                reader.Close();

                return servers;
            }
            catch
            {
                return LoadServers();
            }
        }

        public static void SaveServers(List<ServerInstance> servers)
        {
            List<ServerInstance> clone = new List<ServerInstance>();
            foreach (ServerInstance instance in servers)
            {
                clone.Add((ServerInstance)instance.Clone());
            }
            foreach (ServerInstance instance in clone)
            {
                instance.SetStatusOffline();
            }

            try
            {
                string data = SerializeToString(clone);
                StreamWriter writer = File.CreateText(FILENAME);
                writer.WriteLine(data);
                writer.Flush();
                writer.Close();
            }
            catch
            {
                SaveServers(servers);
            }
        }

        private static string SerializeToString(List<ServerInstance> servers)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, servers);
                stream.Flush();
                stream.Position = 0;
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        private static List<ServerInstance> DeserializeFromString(string data)
        {
            byte[] b = Convert.FromBase64String(data);
            using (var stream = new MemoryStream(b))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (List<ServerInstance>)formatter.Deserialize(stream);
            }
        }
    }
}
