using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;

namespace DonChuchoHealthCare
{
    public partial class Login : System.Web.UI.Page
    {
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

            using (SqlConnection con = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM usuarios WHERE username=@u AND clave=@c", con);
                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@c", pass);
                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    FormsAuthentication.SetAuthCookie(user, false);
                    Session["Usuario"] = user;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMensaje.Text = "⚠️ Usuario o contraseña incorrectos.";
                }
            }
        }
    }
}
