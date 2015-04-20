using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crowdsound_Master_Server_Application.Support
{
    public static class Helper
    {
        public static string GenerateRandomIpAdress()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            string adress = string.Empty;
            int block = 0;

            for (int c = 0; c < 4; c++)
            {
                for (int i = 0; i < rand.Next(0, 128); i++)
                {
                    block = rand.Next(0, 256);
                }
                adress += block.ToString() + ".";
            }
            return adress.Substring(0, adress.Length - 1);
        }
    }
}
