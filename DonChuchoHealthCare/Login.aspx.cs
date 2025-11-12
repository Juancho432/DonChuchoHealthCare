using System;
using System.Web.Security;
using CapaNegocio;

namespace DonChuchoHealthCare
{
    public partial class Login : System.Web.UI.Page
    {
        CN_Login objCN = new CN_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Si ya hay sesión activa, redirige directamente al Dashboard
            if (Session["Usuario"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtClave.Text.Trim();

            if (objCN.Autenticar(user, pass))
            {
                FormsAuthentication.SetAuthCookie(user, false);
                Session["Usuario"] = user;
                Response.Redirect("Default.aspx");
            }
        }
    }
}
