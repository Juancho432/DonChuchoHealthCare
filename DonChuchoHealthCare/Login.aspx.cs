using CapaNegocio;
using System;
using System.Data.SqlClient;
using System.Web.Security;

namespace DonChuchoHealthCare
{
    public partial class Login : System.Web.UI.Page
    {
        CN_Login objCN = new CN_Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 1. Verificar si existen usuarios en la BBDD
                //using (SqlConnection con = new SqlConnection(
                //    System.Configuration.ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString))
                //{
                //    con.Open();
                //    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM usuarios", con);
                //    int total = (int)cmd.ExecuteScalar();

                //    if (total == 0)
                //    {
                //       // No hay usuarios → Redirigir al registro de administrador
                //        Response.Redirect("RegistrarAdmin.aspx");
                //        return;
                //    }
                //}

                // 2. Si ya existe sesión activa → Mandar al Dashboard
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
