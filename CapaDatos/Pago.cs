using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Pago
    {
        public int id_pago { get; set; }
        public int id_poliza { get; set; }
        public string id_cliente { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha_pago { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public decimal monto { get; set; }
        public string forma_pago { get; set; }
        public string numero_comprobante { get; set; }
        public string estado_pago { get; set; }
    }
}
