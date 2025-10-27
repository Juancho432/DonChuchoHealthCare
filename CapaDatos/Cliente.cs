using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Cliente
    {
        public string IdCliente { get; set; }           
        public string TipoDocumento { get; set; }       // CC, CE, NIT, Pasaporte
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string HistorialCrediticio { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
