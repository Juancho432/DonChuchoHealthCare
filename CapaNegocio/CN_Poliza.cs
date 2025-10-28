using System;

namespace CapaNegocio
{

    public enum EstadoPoliza
    {
        Vigente,
        Vencida,
        Renovacion,
        Cancelada
    }

    public struct Poliza
    {
        public int id_poliza;
        public string numero_poliza;
        public string id_cliente;
        public int id_seguro;
        public DateTime fecha_inicio;
        public DateTime fecha_fin;
        public EstadoPoliza estado;
        public DateTime vencimiento;
        public string motivo_cancelacion;
        public DateTime fecha_creacion;
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
