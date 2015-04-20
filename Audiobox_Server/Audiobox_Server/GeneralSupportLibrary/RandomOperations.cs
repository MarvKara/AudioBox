using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSupportLibrary
{
    public static class RandomOperations
    {
        private static Random _rnd;

        /// <summary>
        /// Always call this Method first!
        /// </summary>
        public static void Initialize()
        {
            _rnd = new Random();
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var random = _rnd;
            var result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }
        public static string GenerateRandomNumber(int length)
        {
            const string chars = "123456789";
            var random = _rnd;
            var result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }
    }
}
