
using System;
using System.Configuration;
using CapaDatos;
using Entidades;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private readonly CD_Usuario objCD = new CD_Usuario();

        public void RegistrarUsuario(Usuario usuario)
        {
            objCD.InsertarUsuario(usuario);
        }
    }
}
