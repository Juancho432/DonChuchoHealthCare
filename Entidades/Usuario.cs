using System;

namespace Entidades
{
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
