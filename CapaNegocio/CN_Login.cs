using System;
using System.Security.Cryptography;
using System.Text;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Login
    {

        private readonly CD_Usuario objCD = new CD_Usuario();

        public bool Autenticar(string usuario, string contrasena)
        {
            return true;
            //return !(objCD.ValidarUsuario(usuario, CrearHash(contrasena)) is null);
        }

        public string CrearHash(string data)
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
    
        public bool ComprobarAdmins()
        {
            return objCD.ExisteAdministrador();
        }
    }
}
