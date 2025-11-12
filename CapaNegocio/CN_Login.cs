using System;
using System.Security.Cryptography;
using System.Text;

namespace CapaNegocio
{
    public class CN_Login
    {
        public void Autenticar(string usuario, string contrasena)
        {

        }

        public String CrearHash(string data)
        {
            SHA256 hash = SHA256.Create();
            byte[] data_bytes = Encoding.UTF8.GetBytes(data);
            byte[] result_bytes = hash.ComputeHash(data_bytes);

            StringBuilder result = new StringBuilder(result_bytes.Length * 2);
            foreach (byte b in result_bytes)
            {
                result.AppendFormat("{0:x2}", b);
            }

            return result.ToString();

        }
    }
}
