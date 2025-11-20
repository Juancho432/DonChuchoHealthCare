
using Entidades;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Seguro
    {
        private readonly CD_Seguro objCD = new CD_Seguro();

        public DataTable ListarSeguros()
        {
            return objCD.ListarSeguros();
        }

        public bool InsertarSeguro(Seguro seguro)
        {
            objCD.InsertarSeguro(seguro);
            return true; 
        }
    }
}
