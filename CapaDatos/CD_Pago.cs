using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using Entidades;

namespace CapaDatos
{
    public class CD_Pago
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        // ===============================
        // INSERTAR
        // ===============================
        public void Insertar(Pago pago)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                string sql = @"INSERT INTO pagos 
                          (id_poliza, id_cliente, id_usuario, fecha_pago, monto, forma_pago, numero_comprobante, estado_pago)
                          VALUES (@id_poliza, @id_cliente, @id_usuario, @fecha_pago, @monto, @forma_pago, @numero_comprobante, @estado_pago)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_poliza", pago.id_poliza);
                cmd.Parameters.AddWithValue("@id_cliente", pago.id_cliente);
                cmd.Parameters.AddWithValue("@id_usuario", pago.id_usuario);
                cmd.Parameters.AddWithValue("@fecha_pago", pago.fecha_pago);
                cmd.Parameters.AddWithValue("@monto", pago.monto);
                cmd.Parameters.AddWithValue("@forma_pago", pago.forma_pago);
                cmd.Parameters.AddWithValue("@numero_comprobante", pago.numero_comprobante);
                cmd.Parameters.AddWithValue("@estado_pago", pago.estado_pago);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ===============================
        // ACTUALIZAR
        // ===============================
        public void Actualizar(Pago pago)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                string sql = @"UPDATE pagos SET 
                            id_poliza=@id_poliza,
                            id_cliente=@id_cliente,
                            id_usuario=@id_usuario,
                            fecha_pago=@fecha_pago,
                            monto=@monto,
                            forma_pago=@forma_pago,
                            numero_comprobante=@numero_comprobante,
                            estado_pago=@estado_pago
                           WHERE id_pago=@id_pago";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_pago", pago.id_pago);
                cmd.Parameters.AddWithValue("@id_poliza", pago.id_poliza);
                cmd.Parameters.AddWithValue("@id_cliente", pago.id_cliente);
                cmd.Parameters.AddWithValue("@id_usuario", pago.id_usuario);
                cmd.Parameters.AddWithValue("@fecha_pago", pago.fecha_pago);
                cmd.Parameters.AddWithValue("@monto", pago.monto);
                cmd.Parameters.AddWithValue("@forma_pago", pago.forma_pago);
                cmd.Parameters.AddWithValue("@numero_comprobante", pago.numero_comprobante);
                cmd.Parameters.AddWithValue("@estado_pago", pago.estado_pago);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ===============================
        // ELIMINAR
        // ===============================
        public void Eliminar(int id_pago)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                string sql = "DELETE FROM pagos WHERE id_pago=@id_pago";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_pago", id_pago);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ===============================
        // LISTAR TODO
        // ===============================
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                string sql = @"SELECT 
                            p.id_pago,
                            p.id_poliza,
                            po.numero_poliza,
                            c.nombre AS cliente,
                            p.monto,
                            p.fecha_pago,
                            p.forma_pago,
                            p.estado_pago,
                            p.numero_comprobante
                          FROM pagos p
                          INNER JOIN clientes c ON p.id_cliente = c.id_cliente
                          INNER JOIN polizas po ON p.id_poliza = po.id_poliza
                          ORDER BY p.fecha_pago DESC;";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(dt);
            }
            return dt;
        }

        // ===============================
        // LISTAR POR ESTADO
        // ===============================
        public DataTable ListarPorEstado(string estado_pago)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                string sql = @"SELECT 
                            p.id_pago,
                            po.numero_poliza,
                            c.nombre AS cliente,
                            p.monto,
                            p.fecha_pago,
                            p.forma_pago,
                            p.estado_pago,
                            p.numero_comprobante
                          FROM pagos p
                          INNER JOIN clientes c ON p.id_cliente = c.id_cliente
                          INNER JOIN polizas po ON p.id_poliza = po.id_poliza
                          WHERE p.estado_pago = @estado_pago
                          ORDER BY p.fecha_pago ASC;";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@estado_pago", estado_pago);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // ===============================
        // ACTUALIZAR ESTADOS AUTOMÁTICAMENTE
        // ===============================
        public void ActualizarEstadoPagos()
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                string sql = @"
                    UPDATE pagos
                    SET estado_pago = 'Atrasado'
                    WHERE estado_pago = 'Pendiente'
                    AND fecha_pago < CURDATE();";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ===============================
        // HISTORIAL CREDITICIO CLIENTE
        // ===============================
        public DataTable ObtenerHistorialCrediticioCliente(string id_cliente)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                string sql = @"SELECT 
                            p.id_pago,
                            po.numero_poliza,
                            p.monto,
                            p.fecha_pago,
                            p.estado_pago,
                            s.nombre AS tipo_seguro,
                            p.numero_comprobante
                          FROM pagos p
                          INNER JOIN polizas po ON p.id_poliza = po.id_poliza
                          INNER JOIN seguros s ON po.id_seguro = s.id_seguro
                          WHERE p.id_cliente = @id_cliente
                          AND (p.estado_pago = 'Pendiente' OR p.estado_pago = 'Atrasado')
                          ORDER BY p.fecha_pago ASC;";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable BuscarPorComprobante(string numero_comprobante)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                string sql = @"SELECT 
                        p.id_pago,
                        p.id_poliza,
                        po.numero_poliza,
                        c.nombre AS cliente,
                        p.monto,
                        p.fecha_pago,
                        p.forma_pago,
                        p.estado_pago,
                        p.numero_comprobante
                       FROM pagos p
                       INNER JOIN clientes c ON p.id_cliente = c.id_cliente
                       INNER JOIN polizas po ON p.id_poliza = po.id_poliza
                       WHERE p.numero_comprobante = @numero_comprobante";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@numero_comprobante", numero_comprobante);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }


    }
}


