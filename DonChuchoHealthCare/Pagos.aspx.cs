
using CapaNegocio;
using Entidades;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonChuchoHealthCare
{
    public partial class Pagos : Page
    {

        private readonly CN_Pago objCN_Pago = new CN_Pago();
        private readonly CN_Poliza objCN_Poliza = new CN_Poliza();
        private readonly CN_Cliente objCN_Cliente = new CN_Cliente();

        private void RecargarDatos()
        {
            ddl_poliza.DataSource = objCN_Poliza.ListarPolizas();
            ddl_poliza.DataTextField = "numero_poliza";
            ddl_poliza.DataValueField = "id_poliza";
            ddl_poliza.DataBind();

            ddl_cliente.DataSource = objCN_Cliente.ListarClientes();
            ddl_cliente.DataTextField = "nombre";
            ddl_cliente.DataValueField = "id_cliente";
            ddl_cliente.DataBind();

            string formaPago = ddl_forma_pago.SelectedValue;
            ddl_forma_pago.Items.Clear();
            foreach (Forma_Pago forma in Enum.GetValues(typeof(Forma_Pago)))
            {
                ddl_forma_pago.Items.Add(
                    new ListItem(forma.ToString(), ((int)forma).ToString())
                );
            }
            ddl_forma_pago.SelectedValue = formaPago;

            string estadoPago = ddl_estado_pago.SelectedValue;
            ddl_estado_pago.Items.Clear();
            foreach (Estado_Pago estado in Enum.GetValues(typeof(Estado_Pago)))
            {
                ddl_estado_pago.Items.Add(
                    new ListItem(estado.ToString(), ((int)estado).ToString())
                );
            }
            ddl_estado_pago.SelectedValue = estadoPago;

            gv_listadoPagos.DataSource = objCN_Pago.ListarPagos();
            gv_listadoPagos.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RecargarDatos();
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

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Pago data = new Pago
            {
                id_poliza = int.Parse(ddl_poliza.SelectedValue),
                id_cliente = ddl_cliente.SelectedValue,
                fecha_pago = DateTime.Parse(txt_fecha_pago.Text),
                monto = decimal.Parse(txt_monto.Text),
                forma_pago = (Forma_Pago)int.Parse(ddl_forma_pago.SelectedValue),
                numero_comprobante = txt_numero_comprobante.Text,
                estado_pago = (Estado_Pago)int.Parse(ddl_estado_pago.SelectedValue)
            };

            objCN_Pago.CrearPago(data);
            RecargarDatos();
        }
    }
}