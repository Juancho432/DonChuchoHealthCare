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

        public Cliente BuscarCliente(string id)
        {
            return objCD.BuscarCliente(id);
        }

        public bool ActualizarCliente(Cliente data)
        {
            objCD.ActualizarCliente(data);
            return true;
        }

        public void EliminarCliente(string id)
        {
            objCD.EliminarCliente(id);
        }
    }
}
