using System;
using System.IO;
using System.Windows.Forms;
using Crowdsound_Slave_Server_Application.Support;

namespace Crowdsound_Slave_Server_Application.General
{
    /// <summary>
    /// Static Class for General methods which are used all over the application
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2014
    /// </summary>
    public static class Actions
    {
        /// <summary>
        /// Terminates the server with all its subthreads and closes the application
        /// </summary>
        public static void TerminateServer()
        {
            if (MessageBox.Show("Terminate Server?", "Warning! Possible data loss", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Builds a URL string for a MediaServer-typed object
        /// </summary>
        /// <param name="port"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static string BuildUrlString(string sessionId, int port, char range)
        {
            if (range == 'e')
            {
                return Settings.APPLICATION_URL + ":" + port.ToString() + "/" + sessionId + "/";
            }
            else if (range == 'l')
            {
                return "http://127.0.0.1:" + port.ToString() + "/" + sessionId + "/";
            }
            else
            {
                return null;
            }
        }

        public static string BuildCommandListenerUrlString(char range)
        {
            if (range == 'e')
            {
                return Settings.APPLICATION_URL + ":" + Settings.COMMAND_LISTENER_PORT.ToString() + "/";
            }
            else
            {
                return "http://127.0.0.1:" + Settings.COMMAND_LISTENER_PORT.ToString() + "/";
            }
        }

        /// <summary>
        /// Generates a random char containing a character between A and Z
        /// </summary>
        /// <returns></returns>
        public static char GenerateRandomChar()
        {
            char[] chars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 
                           'T','U','V','W','X','Y','Z'};

            return chars[GeneralObjects.random.Next(0,chars.Length)];
        }

        /// <summary>
        /// Generates a random char containing a number between 0 and 9
        /// </summary>
        /// <returns></returns>
        public static char GenerateRandomNumber()
        {
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            return numbers[GeneralObjects.random.Next(0, numbers.Length)];
        }

        /// <summary>
        /// Creates a file with a given name and extension
        /// </summary>
        /// <param name="name"></param>
        /// <param name="extension"></param>
        public static void CreateFile(string name, string extension)
        {
            var file = new FileInfo(name + "." + extension);
            if (!file.Exists)
            {
                file.Create();
            }
        }

        /// <summary>
        /// Deletes a file at the given path
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch
            {
                DeleteFile(path);
            }
        }

        /// <summary>
        /// Creates a folder with the given name in the working directory of the application
        /// </summary>
        /// <param name="folderName"></param>
        public static void CreateFolder(string folderName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string newFolderPath = folderName;

            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(folderName);
            }
        }

        /// <summary>
        /// Deletes a folder with the given name in the working directory of the application
        /// </summary>
        /// <param name="folderName"></param>
        public static void DeleteFolder(string folderName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string folderPathToDelete = folderName;

            if (Directory.Exists(folderPathToDelete))
            {
                try
                {
                    Directory.Delete(folderName, true);
                }
                catch
                {
                    
                }
            }
        }

        /// <summary>
        /// checks if a char is number or not
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool CharIsNumber(char c)
        {
            if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '0')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Translates the portrange to an understandeble format for the mediaserver
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] TranslatePortRange(int[] input)
        {
            int portRangeLength = (input[1] - input[0]);
            int[] output = new int[portRangeLength + 1];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = input[0] + i;
            }
            return output;
        }

        /// <summary>
        /// Resolves the message from the execution section to a readable http status code.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int ResolveToHttpStatusCode(string message)
        {
            switch (message)
            {
                case "ERROR":
                    {
                        return 400;
                    }
                case "UNAUTHORIZED":
                    {
                        return 401;
                    }
                case "FORBIDDEN":
                    {
                        return 403;
                    }
                case "PARSER_ERROR":
                    {
                        return 422;
                    }
                case "NOT_IMPLEMENTED":
                    {
                        return 501;
                    }
                default:
                    {
                        return 200;
                    }
            }
        }
    }
}
