using System;

namespace Entidades
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
        public string motivo_cancelacion;
        public DateTime fecha_creacion;
    }
}
