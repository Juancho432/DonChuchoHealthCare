using System;
using System.Web.UI;

namespace DonChuchoHealthCare
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paginaActual = Page.AppRelativeVirtualPath.ToLower();

            // Permitir solo acceso al login sin sesión
            if (Session["usuario"] == null && !paginaActual.Contains("login.aspx"))
            {
                Response.Redirect("Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Cerrar sesión
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}