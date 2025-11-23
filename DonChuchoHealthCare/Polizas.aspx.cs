using CapaNegocio;
using Entidades;
using System;
using System.Web.UI;


namespace DonChuchoHealthCare
{
    public partial class Polizas : Page
    {
        private readonly CN_Poliza objCN_Poliza = new CN_Poliza();
        private readonly CN_Cliente objCN_Cliente = new CN_Cliente();
        private readonly CN_Seguro objCN_Seguro = new CN_Seguro();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gv_polizas.DataSource = objCN_Poliza.ListarPolizas();
                gv_polizas.DataBind();

                ddl_cliente.DataSource = objCN_Cliente.ListarClientes();
                ddl_cliente.DataTextField = "nombre";
                ddl_cliente.DataValueField = "id_cliente";
                ddl_cliente.DataBind();

                ddl_seguro.DataSource = objCN_Seguro.ListarSeguros();
                ddl_seguro.DataTextField = "nombre";
                ddl_seguro.DataValueField = "id_seguro";
                ddl_seguro.DataBind();
            }
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_numero_poliza.Text = "";
            ddl_cliente.SelectedIndex = 0;
            ddl_seguro.SelectedIndex = 0;
            txt_fecha_inicio.Text = "";
            txt_fecha_fin.Text = "";
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Poliza data = new Poliza
            {
                numero_poliza = txt_numero_poliza.Text,
                id_cliente = ddl_cliente.SelectedValue,
                id_seguro = Convert.ToInt32(ddl_seguro.SelectedValue),
                fecha_inicio = Convert.ToDateTime(txt_fecha_inicio.Text),
                fecha_fin = Convert.ToDateTime(txt_fecha_fin.Text),
                estado = EstadoPoliza.Vigente,
                fecha_creacion = DateTime.Now
            };

            objCN_Poliza.CrearPoliza(data);
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            Poliza data = objCN_Poliza.BuscarPoliza(txt_buscarPoliza.Text);

            txt_numero_admin.ReadOnly = false;
            ddl_estado_admin.Enabled = true;
            txt_motivo_admin.ReadOnly = false;

            txt_numero_admin.Text = data.numero_poliza;
            ddl_estado_admin.SelectedValue = ((int)data.estado).ToString();
            txt_motivo_admin.Text = data.motivo_cancelacion;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            objCN_Poliza.CancelarPoliza(txt_buscarPoliza.Text);
            gv_polizas.DataSource = objCN_Poliza.ListarPolizas();
            gv_polizas.DataBind();
        }
    }
}