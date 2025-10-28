using System;
using System.Web.UI;

namespace DonChuchoHealthCare
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                pnlLogin.Visible = false;
                pnlPrincipal.Visible = true;
            }
            else
            {
                pnlLogin.Visible = true;
                pnlPrincipal.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Validación simulada
            if (txtUsuario.Text == "admin" && txtClave.Text == "1234")
            {
                Session["Usuario"] = txtUsuario.Text;
                pnlLogin.Visible = false;
                pnlPrincipal.Visible = true;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            pnlLogin.Visible = true;
            pnlPrincipal.Visible = false;
        }
    }
}
