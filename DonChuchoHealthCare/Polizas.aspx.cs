using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonChuchoHealthCare
{
    public partial class Polizas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_numero_poliza.Text = "";
            ddl_cliente.SelectedIndex = 0;
            ddl_seguro.SelectedIndex = 0;
            txt_fecha_inicio.Text = "";
            txt_fecha_fin.Text = "";
            ddl_estado.SelectedIndex = 0;
            txt_motivo_cancelacion.Text = "";
        }
    }
}