
using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using Entidades;

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
                        (id_cliente, tipo_documento, nombre, apellidos, fecha_nacimiento, direccion, telefono, correo)
                        VALUES (@id, @tipo, @nombre, @apellidos, @fecha, @direccion, @telefono, @correo)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", c.id_cliente);
                cmd.Parameters.AddWithValue("@tipo", c.tipo_documento);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@apellidos", c.apellidos);
                cmd.Parameters.AddWithValue("@fecha", c.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@direccion", c.direccion);
                cmd.Parameters.AddWithValue("@telefono", c.telefono);
                cmd.Parameters.AddWithValue("@correo", c.correo);

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
                            correo=@correo
                        WHERE id_cliente=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", c.id_cliente);
                cmd.Parameters.AddWithValue("@tipo", (int)c.tipo_documento);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@apellidos", c.apellidos);
                cmd.Parameters.AddWithValue("@fecha", c.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@direccion", c.direccion);
                cmd.Parameters.AddWithValue("@telefono", c.telefono);
                cmd.Parameters.AddWithValue("@correo", c.correo);

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
        public Cliente BuscarCliente(string idCliente)
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

            if (dt.Rows.Count == 0)
            {
                throw new Exception("Sin resultados");
            }
            else
            {
                DataRow data = dt.Rows[0];
                return new Cliente
                {
                    id_cliente = data["id_cliente"].ToString(),
                    tipo_documento = (Tipo_Documento)Enum.Parse(typeof(Tipo_Documento), data["tipo_documento"].ToString()),
                    nombre = data["nombre"].ToString(),
                    apellidos = data["apellidos"].ToString(),
                    fecha_nacimiento = DateTime.Parse(data["fecha_nacimiento"].ToString()),
                    direccion = data["direccion"].ToString(),
                    telefono = data["telefono"].ToString(),
                    correo = data["correo"].ToString(),
                    fecha_registro = DateTime.Parse(data["fecha_registro"].ToString()),

                };
            }
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

        public DataTable ObtenerHistorialCrediticio(string idCliente)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                string sql = @"
            SELECT 
                c.id_cliente,
                CONCAT(c.nombre, ' ', c.apellidos) AS cliente,
                s.nombre AS seguro,
                p.numero_poliza,
                pa.fecha_pago,
                pa.fecha_vencimiento,
                pa.monto,
                pa.estado_pago
            FROM clientes c
            INNER JOIN polizas p ON c.id_cliente = p.id_cliente
            INNER JOIN seguros s ON p.id_seguro = s.id_seguro
            LEFT JOIN pagos pa ON p.id_poliza = pa.id_poliza
            WHERE c.id_cliente = @idCliente
            ORDER BY pa.fecha_pago DESC;";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        public bool ExisteAdministrador()
        {
            int cantidad = 0;

            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = "SELECT COUNT(*) FROM usuarios WHERE rol = @rol";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@rol", (int)Rol_Usuario.Administrador);

                con.Open();
                cantidad = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return cantidad > 0;
        }

    }
}
