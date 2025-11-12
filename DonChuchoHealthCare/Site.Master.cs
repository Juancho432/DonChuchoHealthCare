using System;
using System.Web.Security;
using System.Web.UI;

namespace DonChuchoHealthCare
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paginaActual = Page.AppRelativeVirtualPath.ToLower();

            // permitir Login.aspx sin sesión
            if (Session["Usuario"] == null && !paginaActual.Contains("login.aspx"))
            {
                Response.Redirect("Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }
    }
}