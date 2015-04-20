using System.Collections.Generic;
using System.IO;
using System.Linq;
using Crowdsound_Master_Server_Application.General;

namespace Crowdsound_Master_Server_Application.Support
{
    /// <summary>
    /// Class which contains all Settings
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public static class Settings
    {
        #region INIT_VALUES

        private const string FILENAME = "settings.csst";

        private const string INIT_APPLICATION_URL = "http://outcast-prophets.no-ip.org";
        private static int[] INIT_STREAM_PORTRANGE = new int[]{ 8001,8020};
        private static int INIT_COMMAND_LISTENER_PORT = 9999; 

        #endregion

        public static string APPLICATION_URL;
        public static int[] STREAM_PORTRANGE;
        public static int COMMAND_LISTENER_PORT;

        public static void Initialize()
        {
            var file = new FileInfo(FILENAME);
            if (!file.Exists)
            {
                SetInitial();
            }

            APPLICATION_URL = (string)Load("APPLICATION_URL");
            STREAM_PORTRANGE = (int[])Load("STREAM_PORTRANGE");
            COMMAND_LISTENER_PORT = (int)Load("COMMAND_LISTENER_PORT");
        }

        private static object Load(string setting)
        {
            var file = new FileInfo(FILENAME);
            List<string> settings = new List<string>();

            string line;
            using(StreamReader reader = new StreamReader(file.ToString()))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    settings.Add(line);
                }
            }

            switch (setting)
            {
                case "APPLICATION_URL":
                    {
                        var result = settings[0];
                        return result;
                    }
                case "STREAM_PORTRANGE":
                    {
                        string[] split = settings[1].Split('#');
                        int[] result = new int[split.Length-1];

                        result[0] = int.Parse(split[0]);
                        result[1] = int.Parse(split[1]);
                        return result;
                    }
                case "COMMAND_LISTENER_PORT":
                    {
                        var result = int.Parse(settings[2]);
                        return result;
                    }
                default:
                    {
                        return null;
                    }
            } 
        }

        public static void Save(List<object> settings)
        {
            APPLICATION_URL = (string)settings[0];
            STREAM_PORTRANGE = (int[])settings[1];
            COMMAND_LISTENER_PORT = (int)settings[2];

            Actions.DeleteFile(FILENAME);
            StreamWriter writer = File.CreateText(FILENAME);

            writer.WriteLine(APPLICATION_URL);
            foreach (int i in STREAM_PORTRANGE)
            {
                writer.Write(i + "#");
            }
            writer.Write("\n");
            writer.WriteLine(COMMAND_LISTENER_PORT);
            writer.Flush();
            writer.Close();
        }

        private static void SetInitial()
        {
            StreamWriter writer = File.CreateText(FILENAME);

            writer.WriteLine(INIT_APPLICATION_URL);
            foreach (int i in INIT_STREAM_PORTRANGE)
            {
                writer.Write(i + "#");
            }
            writer.Write("\n");
            writer.WriteLine(INIT_COMMAND_LISTENER_PORT);
            writer.Flush();
            writer.Close();
        }

        public static object ParseSetting(string setting, string value)
        {
            switch (setting)
            {
                case "APPLICATION_URL":
                    {
                        if (!value.Contains("http://"))
                        {
                            return null;
                        }
                        else
                        {
                            return value;
                        }
                    }
                case "STREAM_PORTRANGE":
                    {
                        int start;
                        int end;

                        if (value.Length > 11)
                        {
                            return null;
                        }

                        if (!value.Contains(':'))
                        {
                            return null;
                        }

                        try
                        {
                            start = int.Parse(value.Split(':')[0]);
                            end = int.Parse(value.Split(':')[1]);
                        }
                        catch
                        {
                            return null;
                        }

                        if (start > end)
                        {
                            return null;
                        }

                        int colonCounter = 0;
                        foreach (char c in value)
                        {
                            if (c == ':')
                            {
                                colonCounter++;
                            }
                            if (!Actions.CharIsNumber(c) && !(c == ':'))
                            {
                                return null;
                            }
                        }
                        if (colonCounter > 1)
                        {
                            return null;
                        }

                        return new int[] { start, end };
                    }
                case "COMMAND_LISTENER_PORT":
                    {
                        if (int.Parse(value) > 9900 && int.Parse(value) < 10000)
                        {
                            return value;
                        }
                        else
                        {
                            return null;
                        }
                    }

                default:
                    {
                        return null;
                    }
            }
        }
    }
}
