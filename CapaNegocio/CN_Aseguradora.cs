
using CapaDatos;
using System.Data;

namespace CapaNegocio
{

    public class CN_Aseguradora
    {
        private readonly CD_Aseguradora objCD = new CD_Aseguradora();

        public DataTable ListarAseguradoras()
        {
            return objCD.ListarAseguradoras();
        }
    }
}
