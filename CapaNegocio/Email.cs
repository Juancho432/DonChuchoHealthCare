using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Email
    {
        public static bool ComprobarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patron, RegexOptions.IgnoreCase);
        }
    }
}
