using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashPassword
{
    interface IHash
    {
        public string HashinPassword(string password);
    }

    internal class HashPassword : IHash
    {
        public static IHash Hash()
        {
            HashPassword hash = new HashPassword();
            return hash;
        }
        public string HashinPassword(string password)
        {
            MD5 mD5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = mD5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder(); 
            foreach(var a in hash)
            {
                sb.Append(a.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
