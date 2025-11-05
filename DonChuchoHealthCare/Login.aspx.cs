using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonChuchoHealthCare
{
    public partial class Login : Page
    {
        protected void btn_ingresar_Click(object sender, EventArgs e)
        {
            string usuario = txt_usuario.Text;
            string contraseña = txt_contraseña.Text;

            // Simulación de login sin base de datos
            if (usuario == "admin" && contraseña == "1234")
            {
                // Guardar usuario en la sesión
                Session["usuario"] = usuario;

                // Redirigir al panel principal
                Response.Redirect("Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest(); // Evita re-ejecución del ciclo
            }
            else
            {
                lbl_mensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}