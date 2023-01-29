using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Shared.Common
{
    public static class CryptHash
    {
        public static string ToSHA256(string s)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

            var sb = new StringBuilder();
            foreach (var item in bytes)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
