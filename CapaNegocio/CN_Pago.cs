using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{

    public enum Forma_Pago
    {

    }

    public struct Pago
    {
        public string id;
        public Cliente cliente;
        public Forma_Pago forma_pago;
        public decimal monto;
        public int cuotas;

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
