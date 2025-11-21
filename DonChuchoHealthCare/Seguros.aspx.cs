using System;
using System.Web.UI;
using CapaNegocio;
using Entidades;

namespace DonChuchoHealthCare
{
    public partial class Seguros : Page
    {

        private readonly CN_Seguro objCN = new CN_Seguro();

        protected void Page_Load(object sender, EventArgs e)
        {
            gv_seguros.DataSource = objCN.ListarSeguros();
            gv_seguros.DataBind();
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Seguro data = new Seguro
            {
                nombre = txt_nombre.Text,
                tipo_seguro = (Tipo_Seguro)ddl_tipo.SelectedIndex + 1,
                cobertura = txt_cobertura.Text,
                costo = decimal.Parse(txt_costo.Text),
                duracion_meses = int.Parse(txt_duracion.Text),
                id_aseguradora = int.Parse(ddl_aseguradora.SelectedValue),
                estado = Estado_Seguro.Activo,
                beneficios = txt_beneficios.Text,
                exclusiones = txt_exclusiones.Text,
                condiciones = txt_condiciones.Text
            };

            objCN.InsertarSeguro(data);
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_nombre.Text = "";
            ddl_tipo.SelectedIndex = 0;
            txt_cobertura.Text = "";
            txt_costo.Text = "";
            txt_duracion.Text = "";
            ddl_aseguradora.SelectedIndex = 0;
            txt_beneficios.Text = "";
            txt_exclusiones.Text = "";
            txt_condiciones.Text = "";
        }
    }
}