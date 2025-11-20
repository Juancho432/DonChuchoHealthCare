using System;
using System.Data;
using System.Runtime.InteropServices;
using CapaDatos;
using Entidades;

namespace CapaNegocio
{
    public class CN_Poliza
    {
        private readonly CD_Poliza objCD = new CD_Poliza();

        public void CrearPoliza (Poliza data) { }
        public void CancelarPoliza (string id) { }
        public void ActualizarPoliza(Poliza data) { }
        public void BuscarPoliza (string id) { }
        public DataTable ListarPolizas (string id) 
        {
            //objCD.ListarPolizas(id);
            return new DataTable();
        }
        public void GenerarCertificado (Poliza data) { }
    }
}
