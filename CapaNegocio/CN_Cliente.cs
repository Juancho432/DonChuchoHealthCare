using System;

namespace CapaNegocio
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

    public class CN_Cliente
    {
    }
}
