using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using zaliczenie_ld_308.Entities;
using zaliczenie_ld_308.Services;

namespace zaliczenie_ld_308.Utilities
{
    static class Security
    {
        public static class Login
        {
            public static bool Authorize(User userLocal)
            {
                string password = userLocal.Password;
                UserService userService = new UserService();
                User userDb = userService.Get(userLocal);

                if(userLocal == null || userDb == null)
                {
                    return false;
                }

                using (MD5 md5Hash = MD5.Create())
                {
                    bool res = Security.VerifyMd5Hash(md5Hash, password, userDb.Password);
                    return res;
                }
            }
        }

        public static string Hash(string text)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, text);
                return hash;
            }
        }
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
