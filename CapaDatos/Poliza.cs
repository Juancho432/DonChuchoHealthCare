using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Poliza
    {
        public int id_poliza { get; set; }
        public string numero_poliza { get; set; }
        public string id_cliente { get; set; }
        public int id_seguro { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string estado { get; set; }
        public string motivo_cancelacion { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}
