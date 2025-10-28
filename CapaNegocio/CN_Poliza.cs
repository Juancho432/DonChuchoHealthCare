using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{

    public enum EstadoPoliza
    {
        vigente,
        en_renovacion,
        cancelada_vencida,
        cancelada_impago,
        cancelada_peticion
    }

    public struct Poliza
    {
        public string id;
        public Cliente cliente;
        public EstadoPoliza estado;
        public DateTime vencimiento;
    }

    public class CN_Poliza
    {
        public void CrearPoliza (Poliza data) { }
        public void CancelarPoliza (string id) { }
        public void ActualizarPoliza(Poliza data) { }
        public void BuscarPoliza (string id) { }
        public void ListarPolizas () { }
        public void GenerarCertificado (Poliza data) { }
    }
}
