using System;

namespace Entidades
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
        public decimal monto;
        public Forma_Pago forma_pago;
        public string numero_comprobante;
        public Estado_Pago estado_pago;
    }

}
