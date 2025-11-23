using CapaNegocio;
using Entidades;
using System;
using System.Web.UI;

namespace DonChuchoHealthCare
{
    public partial class Registrar_admin : Page
    {
        private readonly CN_Usuario objCN_Usuario = new CN_Usuario();
        private readonly CN_Login objCN_Login = new CN_Login();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(objCN_Login.ComprobarAdmins())
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (txtClave.Text == txtConfirmar.Text && !string.IsNullOrEmpty(txtClave.Text))
            {
                Usuario data = new Usuario
                {
                    id_usuario = 0,
                    usuario = txtUsuario.Text.Trim(),
                    contraseña = objCN_Login.CrearHash(txtClave.Text),
                    rol = Rol_Usuario.Administrador,
                    nombre = txtNombre.Text.Trim(),
                    apellidos = txtApellidos.Text.Trim(),
                    correo = Email.ComprobarCorreo(txtCorreo.Text) ? txtCorreo.Text : throw new Exception("Correo no cumple formato"),
                    estado = Estado_Usuario.Activo,
                    fecha_creacion = DateTime.Now
                };
                
                if (objCN_Login.ComprobarAdmins()) // Comprobar otra vez por si alguien más registró un admin mientras tanto
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                else
                {
                    objCN_Usuario.RegistrarUsuario(data);
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                lblMensaje.CssClass = "msg msg-error";
                lblMensaje.Text = "⚠️ Las contraseñas no coinciden.";
            }
        }
    }
}