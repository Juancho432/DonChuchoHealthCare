using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Cliente
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private string sql = "";

        //Insertar Cliente
        public void InsertarCliente(Cliente c)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"INSERT INTO clientes 
                        (id_cliente, tipo_documento, nombre, apellidos, fecha_nacimiento, direccion, telefono, correo, historial_crediticio)
                        VALUES (@id, @tipo, @nombre, @apellidos, @fecha, @direccion, @telefono, @correo, @historial)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", c.IdCliente);
                cmd.Parameters.AddWithValue("@tipo", c.TipoDocumento);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", c.Apellidos);
                cmd.Parameters.AddWithValue("@fecha", c.FechaNacimiento);
                cmd.Parameters.AddWithValue("@direccion", c.Direccion);
                cmd.Parameters.AddWithValue("@telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@correo", c.Correo);
                cmd.Parameters.AddWithValue("@historial", c.HistorialCrediticio);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Actualizar Cliente
        public void ActualizarCliente(Cliente c)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE clientes 
                        SET tipo_documento=@tipo, nombre=@nombre, apellidos=@apellidos, 
                            fecha_nacimiento=@fecha, direccion=@direccion, telefono=@telefono, 
                            correo=@correo, historial_crediticio=@historial
                        WHERE id_cliente=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", c.IdCliente);
                cmd.Parameters.AddWithValue("@tipo", c.TipoDocumento);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@apellidos", c.Apellidos);
                cmd.Parameters.AddWithValue("@fecha", c.FechaNacimiento);
                cmd.Parameters.AddWithValue("@direccion", c.Direccion);
                cmd.Parameters.AddWithValue("@telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@correo", c.Correo);
                cmd.Parameters.AddWithValue("@historial", c.HistorialCrediticio);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Eliminar Cliente
        public void EliminarCliente(string idCliente)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"DELETE FROM clientes WHERE id_cliente=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idCliente);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Buscar Cliente por documento
        public DataTable BuscarCliente(string idCliente)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM clientes WHERE id_cliente=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idCliente);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Listar todos los clientes
        public DataTable ListarClientes()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT id_cliente, tipo_documento, nombre, apellidos, telefono, correo, fecha_registro 
                        FROM clientes ORDER BY fecha_registro DESC";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }

}

