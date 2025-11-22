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

        public void CrearPoliza (Poliza data) 
        {
            objCD.InsertarPoliza(data);
        }
        public void CancelarPoliza (string id) { }
        public void ActualizarPoliza(Poliza data) { }
        public Poliza BuscarPoliza (string id) 
        {
            DataTable dt = objCD.BuscarPoliza(id);
            Poliza data = new Poliza
            {
                id_poliza = Convert.ToInt32(dt.Rows[0]["id_poliza"]),
                numero_poliza = dt.Rows[0]["numero_poliza"].ToString(),
                id_cliente = dt.Rows[0]["id_cliente"].ToString(),
                id_seguro = Convert.ToInt32(dt.Rows[0]["id_seguro"]),
                fecha_inicio = Convert.ToDateTime(dt.Rows[0]["fecha_inicio"]),
                fecha_fin = Convert.ToDateTime(dt.Rows[0]["fecha_fin"]),
                estado = (EstadoPoliza)Enum.Parse(typeof(EstadoPoliza), dt.Rows[0]["estado"].ToString()),
                motivo_cancelacion = dt.Rows[0]["motivo_cancelacion"].ToString(),
                fecha_creacion = Convert.ToDateTime(dt.Rows[0]["fecha_creacion"])
            };

            return data;
        }

        public DataTable ListarPolizas () 
        {
            return objCD.ListarPolizas();
        }

        public DataTable ListarPolizas (string id) 
        {
            objCD.ListarPolizasPorCliente(id);
            return new DataTable();
        }
    }
}
