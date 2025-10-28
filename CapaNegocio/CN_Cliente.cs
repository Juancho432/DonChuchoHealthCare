using System;

namespace CapaNegocio
{
    public enum Tipo_ID
    {
        Cedula,
        Cedula_Extranjera,
        NIT,
        Pasaporte
    }

    public struct Cliente
    {
        public string id;
        public Tipo_ID tipo_id;
        public string nombre;
        public string apellido;
        public DateTime nacimiento;
        public string direccion;
        public string correo;
    }

    public class CN_Cliente
    {
    }
}
