using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{

    public enum Forma_Pago
    {
        Efectivo,
        Tarjeta,
        Transferencia,
        Cheque
    }

    public enum Estado_Pago
    {
        Completado,
        Pendiente,
        Atrasado
    }

    public struct Pago
    {
        public int id_pago;
        public int id_poliza;
        public string id_cliente;
        public int id_usuario;
        public DateTime fecha_pago;
        //public DateTime fecha_vencimiento;
        public decimal monto;
        public Forma_Pago forma_pago;
        public string numero_comprobante;
        public Estado_Pago estado_pago;
    }

    public class CN_Pago
    {
        public void CrearPago (Pago data) { }
        public void EliminarPago (string id) { }
        public void ActualizarPago (Pago data) { }
        public void BuscarPago (string id) { }
        public void ListarPagos () { }
        public void GenerarRecibo (Pago data) { }
    }
}
