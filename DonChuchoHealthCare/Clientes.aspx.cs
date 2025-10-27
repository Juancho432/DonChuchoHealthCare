using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonChuchoHealthCare
{
    public partial class Clientes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            // Lógica para registrar un nuevo cliente
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            ddl_tipoDocumento.SelectedIndex = 0;
            txt_nombres.Text = "";
            txt_apellidos.Text = "";
            txt_fechaNacimiento.Text = "";
            txt_direccion.Text = "";
            txt_telefono.Text = "";
            txt_correo.Text = "";
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            // Lógica para buscar un cliente
        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            // Lógica para actualizar un cliente
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Lógica para eliminar un cliente
        }
    }
}