using CapaNegocio;
using System;
using System.Web.Security;

namespace DonChuchoHealthCare
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly CN_Login objCN = new CN_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            bool adminsExist = objCN.ComprobarAdmins();
            if (!adminsExist)
            {
                Response.Redirect("Registrar_admin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtClave.Text.Trim();

            // 3. Autenticación usando la capa de negocio
            if (objCN.Autenticar(user, pass))
            {
                FormsAuthentication.SetAuthCookie(user, false);
                Session["Usuario"] = user;

                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
        }
    }
}
