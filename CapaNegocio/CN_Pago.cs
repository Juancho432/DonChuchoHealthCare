using System;
using System.Data;
using CapaDatos;
using Entidades;

namespace CapaNegocio
{
    public class CN_Pago
    {
        private readonly CD_Pago objCD = new CD_Pago();

        public void CrearPago (Pago data) 
        {
            objCD.Insertar(data);
        }

        public void EliminarPago (string id) { }
        public void ActualizarPago (Pago data) { }
        public DataTable BuscarPagoPorComprobante(string numero_comprobante)
        {
            return objCD.BuscarPorComprobante(numero_comprobante);
        }
        public DataTable ListarPagos () 
        {
            return objCD.Listar();
        }
        public void GenerarRecibo (Pago data) { }
    }
}