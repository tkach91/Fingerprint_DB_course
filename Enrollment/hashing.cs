using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Enrollment
{
    class hashing
    {
        public static string useMD5(string data)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] bdata = md5Hasher.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < bdata.Length; i++)
            {
                sBuilder.Append(bdata[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
