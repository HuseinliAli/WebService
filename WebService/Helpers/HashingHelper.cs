using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebService.Helpers
{
    public static class HashingHelper
    {
        public static byte[] CreatePasswordHash(string password)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string requestPassword,byte[] dbPasswordHash)
        {
            var requestPasswordHash = CreatePasswordHash(requestPassword);
            for (int i = 0; i < requestPasswordHash.Length; i++)
            {
                if (requestPasswordHash[i] != dbPasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}