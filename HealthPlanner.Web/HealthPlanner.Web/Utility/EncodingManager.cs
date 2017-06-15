using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HealthPlanner.Web.Utility
{
    public class EncodingManager
    {
        public static string Encode(string input)
        {
            byte[] hashedBytes;

            var encoding = new UTF8Encoding();
            byte[] inputBytes = encoding.GetBytes(input);
            

            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashedBytes = algorithm.ComputeHash(inputBytes);
            }

            return Convert.ToBase64String(hashedBytes);
        }
    }
}