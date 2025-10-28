using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Cliente
    {
        public string id_cliente { get; set; }           
        public string tipo_documento { get; set; }       // CC, CE, NIT, Pasaporte
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}
