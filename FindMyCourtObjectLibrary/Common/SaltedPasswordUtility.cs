using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FindMyCourtObjectLibrary.Common
{
    public static class SaltedPasswordUtility
    {
        public static string GenerateSaltedPassword(string salt, string password)
        {
            byte[] hashBytes;

            using (SHA256 hash = SHA256.Create())
            {
                hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            }

            // Use StringBuilder for performance
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            int size = 256;

            byte[] bytes = new byte[size];
            crypto.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}
