using System;
using CapaDatos;
using Entidades;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private readonly CD_Cliente objCD = new CD_Cliente();

        public void CrearCliente(Cliente data)
        {
            objCD.InsertarCliente(data);
        }
    }
}
