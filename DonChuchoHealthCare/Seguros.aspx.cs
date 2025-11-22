using CapaNegocio;
using Entidades;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonChuchoHealthCare
{
    public partial class Seguros : Page
    {

        private readonly CN_Seguro objCN_Seguro = new CN_Seguro();
        private readonly CN_Aseguradora objCN_Aseguradora = new CN_Aseguradora();

        private void RecargarDatos()
        {
            DataTable aseguradoras = objCN_Aseguradora.ListarAseguradoras();
            ddl_aseguradora.DataSource = aseguradoras;
            ddl_aseguradora.DataTextField = "nombre";
            ddl_aseguradora.DataValueField = "id_aseguradora";
            ddl_aseguradora.DataBind();

            ddl_aseguradoraBusqueda.DataSource = aseguradoras;
            ddl_aseguradoraBusqueda.DataTextField = "nombre";
            ddl_aseguradoraBusqueda.DataValueField = "id_aseguradora";
            ddl_aseguradoraBusqueda.DataBind();

            string tipoSeleccionado = ddl_tipoBusqueda.SelectedValue;
            string tipoAdminSeleccionado = ddl_tipo_admin.SelectedValue;
            string tipoSeleccionadoBusqueda = ddl_tipoBusqueda.SelectedValue;

            ddl_tipo.Items.Clear();
            ddl_tipo_admin.Items.Clear();
            ddl_tipoBusqueda.Items.Clear();

            foreach (Tipo_Seguro tipo in Enum.GetValues(typeof(Tipo_Seguro)))
            {
                ddl_tipo.Items.Add(
                    new ListItem(tipo.ToString(), ((int)tipo).ToString())
                );
                ddl_tipo_admin.Items.Add(
                    new ListItem(tipo.ToString(), ((int)tipo).ToString())
                );
                ddl_tipoBusqueda.Items.Add(
                    new ListItem(tipo.ToString(), ((int)tipo).ToString())
                );
            }

            ddl_tipoBusqueda.SelectedValue = tipoSeleccionado;
            ddl_tipo_admin.SelectedValue = tipoAdminSeleccionado;
            ddl_tipoBusqueda.SelectedValue = tipoSeleccionadoBusqueda;

            gv_seguros.DataSource = objCN_Seguro.ListarSeguros();
            gv_seguros.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RecargarDatos();
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            Seguro data = new Seguro
            {
                nombre = txt_nombre.Text,
                tipo_seguro = (Tipo_Seguro)int.Parse(ddl_tipo.SelectedValue),
                cobertura = txt_cobertura.Text,
                costo = decimal.Parse(txt_costo.Text),
                duracion_meses = int.Parse(txt_duracion.Text),
                id_aseguradora = int.Parse(ddl_aseguradora.SelectedValue),
                estado = Estado_Seguro.Activo,
                beneficios = txt_beneficios.Text,
                exclusiones = txt_exclusiones.Text,
                condiciones = txt_condiciones.Text
            };

            objCN_Seguro.InsertarSeguro(data);
            RecargarDatos();
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

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            Seguro data = objCN_Seguro.BuscarSeguro(int.Parse(txt_buscarSeguro.Text));

            txt_nombre_admin.ReadOnly = false;
            ddl_aseguradoraBusqueda.Enabled = true;
            ddl_tipo_admin.Enabled = true;
            txt_cobertura_admin.ReadOnly = false;
            txt_costo_admin.ReadOnly = false;
            txt_duracion_admin.ReadOnly = false;
            txt_beneficios_admin.ReadOnly = false;
            txt_exclusiones_admin.ReadOnly = false;
            txt_condiciones_admin.ReadOnly = false;

            txt_nombre_admin.Text = data.nombre;
            ddl_tipo_admin.SelectedValue = ((int)data.tipo_seguro).ToString();
            ddl_aseguradoraBusqueda.SelectedValue = data.id_aseguradora.ToString();
            txt_cobertura_admin.Text = data.cobertura;
            txt_costo_admin.Text = data.costo.ToString();
            txt_duracion_admin.Text = data.duracion_meses.ToString();
            txt_beneficios_admin.Text = data.beneficios;
            txt_exclusiones_admin.Text = data.exclusiones;
            txt_condiciones_admin.Text = data.condiciones;
        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            Seguro data = new Seguro
            {
                id_seguro = int.Parse(txt_buscarSeguro.Text),
                nombre = txt_nombre_admin.Text,
                tipo_seguro = (Tipo_Seguro)int.Parse(ddl_tipo_admin.SelectedValue),
                cobertura = txt_cobertura_admin.Text,
                costo = decimal.Parse(txt_costo_admin.Text),
                duracion_meses = int.Parse(txt_duracion_admin.Text),
                id_aseguradora = int.Parse(ddl_aseguradoraBusqueda.SelectedValue),
                beneficios = txt_beneficios_admin.Text,
                exclusiones = txt_exclusiones_admin.Text,
                condiciones = txt_condiciones_admin.Text
            };
            objCN_Seguro.ActualizarSeguro(data);
            RecargarDatos();
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            objCN_Seguro.EliminarSeguro(int.Parse(txt_buscarSeguro.Text));
            RecargarDatos();
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            gv_resultados.DataSource = null;
            gv_resultados.DataBind();

            DataTable data = objCN_Seguro.ListarSeguros();
            var filtrado = data.AsEnumerable()
                .Where(row =>
                    row.Field<string>("tipo").Contains(ddl_tipoBusqueda.SelectedItem.Text) &&
                    row.Field<string>("cobertura").Contains(txt_busquedaCobertura.Text) &&
                    row.Field<decimal>("costo") <= (string.IsNullOrEmpty(txt_costoMax.Text) 
                                                    ? decimal.MaxValue 
                                                    : decimal.Parse(txt_costoMax.Text)) &&
                    row.Field<int>("duracion_meses") >= (string.IsNullOrEmpty(txt_duracionMin.Text)
                                                        ? 0 : int.Parse(txt_duracionMin.Text)) &&
                    row.Field<int>("id_aseguradora") == int.Parse(ddl_aseguradoraBusqueda.Text)
                    );

            try
            {
                gv_resultados.DataSource = filtrado.CopyToDataTable();
                gv_resultados.DataBind();
            }
            catch
            {
                // No hay resultados al filtro
            }

        }
    }
}