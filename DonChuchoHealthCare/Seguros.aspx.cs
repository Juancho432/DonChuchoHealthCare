using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonChuchoHealthCare
{
    public partial class Seguros : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            // Lógica de inserción de nuevo seguro
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_nombre.Text = "";
            ddl_tipo.SelectedIndex = 0;
            txt_cobertura.Text = "";
            txt_costo.Text = "";
            txt_duracion.Text = "";
            ddl_aseguradora.SelectedIndex = 0;
            ddl_estado.SelectedIndex = 0;
            txt_beneficios.Text = "";
            txt_exclusiones.Text = "";
            txt_condiciones.Text = "";
        }
    }
}