using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Seguro
    {
        public int id_seguro { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }//Tipos válidos: Vida, Salud, Automóvil, Hogar, Otro
        public string cobertura { get; set; }
        public decimal costo { get; set; }
        public int duracion_meses { get; set; }
        public string beneficios { get; set; }
        public string exclusiones { get; set; }
        public string condiciones { get; set; }
        public int? id_aseguradora { get; set; }
        public string estado { get; set; } //'Activo' o 'Inactivo'
    }
}

