
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

        //Metodo para convertir DataRow a Cliente
        private Cliente ConvertirFilaACliente(DataRow data)
        {
            return new Cliente
            {
                id_cliente = data["id_cliente"].ToString(),
                tipo_documento = (Tipo_Documento)Enum.Parse(typeof(Tipo_Documento), data["tipo_documento"].ToString()),
                nombre = data["nombre"].ToString(),
                apellidos = data["apellidos"].ToString(),
                fecha_nacimiento = Convert.ToDateTime(data["fecha_nacimiento"]),
                direccion = data["direccion"].ToString(),
                telefono = data["telefono"].ToString(),
                correo = data["correo"].ToString(),
                fecha_registro = Convert.ToDateTime(data["fecha_registro"])
            };
        }

        //Insertar Cliente
        public void InsertarCliente(Cliente c)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"INSERT INTO clientes 
                        (id_cliente, tipo_documento, nombre, apellidos, fecha_nacimiento, direccion, telefono, correo, estado)
                        VALUES (@id, @tipo, @nombre, @apellidos, @fecha, @direccion, @telefono, @correo, 1)";

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
                cmd.Parameters.AddWithValue("@tipo", c.tipo_documento.ToString());
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

        //Listar solo los clientes activos
        public DataTable ListarActivos()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = "SELECT * FROM clientes WHERE estado = 1";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;
        }

        //Buscar solo los clientes activos
        public Cliente BuscarCliente(string idCliente)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM clientes 
                        WHERE id_cliente=@id AND estado = 1";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idCliente);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count == 0)
                return default; // No lanza excepción → se maneja en la capa presentación

            return ConvertirFilaACliente(dt.Rows[0]);
        }

        //Buscar clientes, incluyendo los clientes inactivos
        public Cliente BuscarIncluyendoInactivos(string idCliente)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM clientes 
                        WHERE id_cliente=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idCliente);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count == 0)
                return default;

            return ConvertirFilaACliente(dt.Rows[0]);
        }

        //Eliminar cliente (dejarlo en estado inactivo)
        public bool Eliminar(string idCliente)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE clientes SET estado = 0
                        WHERE id_cliente=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idCliente);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //Restaurar estado de cliente
        public bool RestaurarCliente(string idCliente)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE clientes SET estado = 1
                        WHERE id_cliente=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idCliente);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //Verificar si existe un cliente
        public bool ExisteCliente(string id)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = "SELECT COUNT(*) FROM clientes WHERE id_cliente=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                return cantidad > 0;
            }
        }

        //Obtener historial crediticio
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

    }
}
