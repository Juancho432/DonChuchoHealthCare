using System;

namespace Entidades
{
    public enum Tipo_Documento
    {
        CC,
        CE,
        NIT,
        Pasaporte
    }

    public struct Cliente
    {
        public string id_cliente;
        public Tipo_Documento tipo_documento;
        public string nombre;
        public string apellidos;
        public DateTime fecha_nacimiento;
        public string direccion;
        public string telefono;
        public string correo;
        public DateTime fecha_registro;
    }

    public struct Aseguradora
    {
        public int id_aseguradora;
        public string nombre;
        public string direccion;
        public string telefono;
        public string correo;
        public string sitio_web;
    }

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

    public enum Tipo_Seguro
    {
        Vida,
        Salud,
        Automovil,
        Hogar,
        Otro
    }

    public enum Estado_Seguro
    {
        Activo,
        Inactivo
    }

    public struct Seguro
    {
        public int id_seguro;
        public string nombre;
        public Tipo_Seguro tipo_seguro;
        public string cobertura;
        public decimal costo;
        public int duracion_meses;
        public string beneficios;
        public string exclusiones;
        public string condiciones;
        public int id_aseguradora;
        public Estado_Seguro estado;
    }

    public enum Rol_Usuario
    {
        Administrador,
        Asesor,
        Gerente
    }

    public enum Estado_Usuario
    {
        Activo,
        Inactivo
    }

    public struct Usuario
    {
        public int id_usuario;
        public string usuario;
        public string contraseña;
        public Rol_Usuario rol;
        public string nombre;
        public string apellidos;
        public string correo;
        public Estado_Usuario estado;
        public DateTime fecha_creacion;
    }
}
