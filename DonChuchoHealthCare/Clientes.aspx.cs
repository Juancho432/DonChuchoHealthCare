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
            // Guardar nuevo cliente (lógica futura)
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
            // Simulación: validar que haya escrito un ID
            if (string.IsNullOrWhiteSpace(txt_buscarId.Text))
            {
                return; // no hace nada si no hay ID
            }

            // Supongamos que encontró un cliente:
            txt_id_admin.Text = txt_buscarId.Text;
            ddl_tipoDocumento_admin.SelectedValue = "CC";
            txt_nombres_admin.Text = "Carlos";
            txt_apellidos_admin.Text = "Pérez";
            txt_fechaNacimiento_admin.Text = "1990-05-12";
            txt_direccion_admin.Text = "Calle 45 #23-10";
            txt_telefono_admin.Text = "3124567890";
            txt_correo_admin.Text = "carlos.perez@example.com";

            // Habilitar campos y botones
            ddl_tipoDocumento_admin.Enabled = true;
            txt_id_admin.ReadOnly = false;
            txt_nombres_admin.ReadOnly = false;
            txt_apellidos_admin.ReadOnly = false;
            txt_fechaNacimiento_admin.ReadOnly = false;
            txt_direccion_admin.ReadOnly = false;
            txt_telefono_admin.ReadOnly = false;
            txt_correo_admin.ReadOnly = false;

            btn_actualizar.Enabled = true;
            btn_eliminar.Enabled = true;
        }


    }
}