using System;
using System.Web.UI;
using CapaNegocio;
using Entidades;

namespace DonChuchoHealthCare
{
    public partial class Clientes : Page
    {
        private readonly CN_Cliente objCN = new CN_Cliente();

        public void btn_guardar_Click(object sender, EventArgs e)
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
        }

        public void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            ddl_tipoDocumento.SelectedIndex = 0;
            txt_nombres.Text = "";
            txt_apellidos.Text = "";
            txt_fechaNacimiento.Text = "";
            txt_direccion.Text = "";
            txt_telefono.Text = "";
            txt_correo.Text = "";
        }

        public void btn_buscar_Click(object sender, EventArgs e)
        { 

            if (string.IsNullOrWhiteSpace(txt_buscarId.Text))
            {
                return; // no hace nada si no hay ID
            }

            Cliente? data = objCN.BuscarCliente(txt_buscarId.Text);

            if (data is Cliente cliente)
            {
                txt_id_admin.Text = cliente.id_cliente;
                ddl_tipoDocumento_admin.SelectedIndex = ((int)cliente.tipo_documento);
                txt_nombres_admin.Text = cliente.nombre;
                txt_apellidos_admin.Text = cliente.apellidos;
                txt_fechaNacimiento_admin.Text = cliente.fecha_nacimiento.Date.ToString();
                txt_direccion_admin.Text = cliente.direccion;
                txt_telefono_admin.Text = cliente.telefono;
                txt_correo_admin.Text = cliente.correo;

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
            }            
        }
    }
}