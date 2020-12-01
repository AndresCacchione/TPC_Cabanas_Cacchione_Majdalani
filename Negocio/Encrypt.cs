using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Negocio
{
    public class Encrypt
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            UnicodeEncoding encoding = new UnicodeEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        // SE USA DE ESTA FORMA string cadenaEncriptada = Encrypt.GetSha256("patito");

    }
}
