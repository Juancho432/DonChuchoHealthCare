using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Historial_Crediticio
    {
        public int id_historial { get; set; }
        public string id_cliente { get; set; }
        public DateTime fecha_registro { get; set; }
        public string descripcion { get; set; }
        public string calificacion { get; set; }
        public decimal monto_adeudado { get; set; }
        public string observaciones { get; set; }
    }
}
