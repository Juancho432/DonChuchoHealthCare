using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonChuchoHealthCare
{
    public partial class Pagos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            ddl_poliza.SelectedIndex = 0;
            ddl_cliente.SelectedIndex = 0;
            txt_fecha_pago.Text = "";
            txt_fecha_vencimiento.Text = "";
            txt_monto.Text = "";
            ddl_forma_pago.SelectedIndex = 0;
            txt_numero_comprobante.Text = "";
            ddl_estado_pago.SelectedIndex = 0;
        }
    }
}