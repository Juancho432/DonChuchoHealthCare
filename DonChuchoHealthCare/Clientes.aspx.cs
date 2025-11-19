using System;
using System.Web.UI;
using CapaNegocio;
using Entidades;

namespace DonChuchoHealthCare
{
    public partial class Clientes : Page
    {
        private readonly CN_Cliente objCN = new CN_Cliente();

        protected void Page_Load(object sender, EventArgs e) { }

        /* ------------------------- GUARDAR ------------------------- */
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            objCN.CrearCliente(new Cliente
            {
                id_cliente = txt_id.Text,
                tipo_documento = (Tipo_Documento)ddl_tipoDocumento.SelectedIndex,
                nombre = txt_nombres.Text,
                apellidos = txt_apellidos.Text,
                fecha_nacimiento = DateTime.Parse(txt_fechaNacimiento.Text),
                direccion = txt_direccion.Text,
                telefono = txt_telefono.Text,
                correo = Email.ComprobarCorreo(txt_correo.Text) ? txt_correo.Text : null,
                fecha_registro = DateTime.Today
            });

            lbl_mensaje.Text = "Cliente registrado correctamente.";
        }

        /* ------------------------- LIMPIAR ------------------------- */
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

            lbl_mensaje.Text = "";
        }

        /* ------------------------- BUSCAR ------------------------- */
        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            lbl_mensaje.Text = ""; // limpiar mensaje previo

            if (string.IsNullOrWhiteSpace(txt_buscarId.Text))
            {
                lbl_mensaje.Text = "⚠️ Ingrese un ID para buscar.";
                return;
            }

            Cliente data = null;

            try
            {
                data = objCN.BuscarCliente(txt_buscarId.Text);
            }
            catch (Exception ex)
            {
                lbl_mensaje.Text = "⚠️ Error al buscar cliente: " + ex.Message;
                return;
            }

            if (data == null)
            {
                lbl_mensaje.Text = "❌ No se encontró ningún cliente con ese ID.";

                // limpiar campos
                txt_id_admin.Text = "";
                ddl_tipoDocumento_admin.SelectedIndex = 0;
                txt_nombres_admin.Text = "";
                txt_apellidos_admin.Text = "";
                txt_fechaNacimiento_admin.Text = "";
                txt_direccion_admin.Text = "";
                txt_telefono_admin.Text = "";
                txt_correo_admin.Text = "";

                // deshabilitar edición
                ddl_tipoDocumento_admin.Enabled = false;
                txt_id_admin.ReadOnly = true;
                txt_nombres_admin.ReadOnly = true;
                txt_apellidos_admin.ReadOnly = true;
                txt_fechaNacimiento_admin.ReadOnly = true;
                txt_direccion_admin.ReadOnly = true;
                txt_telefono_admin.ReadOnly = true;
                txt_correo_admin.ReadOnly = true;

                btn_actualizar.Enabled = false;
                btn_eliminar.Enabled = false;

                return;
            }

            /* --- Si existe el cliente, llenar los campos --- */
            txt_id_admin.Text = data.id_cliente;
            ddl_tipoDocumento_admin.SelectedIndex = (int)data.tipo_documento;
            txt_nombres_admin.Text = data.nombre;
            txt_apellidos_admin.Text = data.apellidos;
            txt_fechaNacimiento_admin.Text = data.fecha_nacimiento.ToString("yyyy-MM-dd");
            txt_direccion_admin.Text = data.direccion;
            txt_telefono_admin.Text = data.telefono;
            txt_correo_admin.Text = data.correo;

            // habilitar edición
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

            lbl_mensaje.Text = "";
        }

        /* ------------------------- ACTUALIZAR ------------------------- */
        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            Cliente data = new Cliente()
            {
                id_cliente = txt_id_admin.Text,
                tipo_documento = (Tipo_Documento)ddl_tipoDocumento_admin.SelectedIndex,
                nombre = txt_nombres_admin.Text,
                apellidos = txt_apellidos_admin.Text,
                fecha_nacimiento = DateTime.Parse(txt_fechaNacimiento_admin.Text),
                direccion = txt_direccion_admin.Text,
                telefono = txt_telefono_admin.Text,
                correo = txt_correo_admin.Text
            };

            objCN.ActualizarCliente(data);

            lbl_mensaje.Text = "✔️ Cliente actualizado correctamente.";
        }
    }
}