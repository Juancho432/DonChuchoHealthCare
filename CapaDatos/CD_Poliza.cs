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
    public class CD_Poliza
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private string sql = "";

        // INSERTAR
        public void InsertarPoliza(Poliza p)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"INSERT INTO polizas (numero_poliza, id_cliente, id_seguro, fecha_inicio, fecha_fin, estado, motivo_cancelacion)
                        VALUES (@numero_poliza, @id_cliente, @id_seguro, @fecha_inicio, @fecha_fin, @estado, @motivo_cancelacion)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@numero_poliza", p.numero_poliza);
                cmd.Parameters.AddWithValue("@id_cliente", p.id_cliente);
                cmd.Parameters.AddWithValue("@id_seguro", p.id_seguro);
                cmd.Parameters.AddWithValue("@fecha_inicio", p.fecha_inicio);
                cmd.Parameters.AddWithValue("@fecha_fin", p.fecha_fin);
                cmd.Parameters.AddWithValue("@estado", p.estado);
                cmd.Parameters.AddWithValue("@motivo_cancelacion", p.motivo_cancelacion);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ACTUALIZAR
        public void ActualizarPoliza(Poliza p)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE polizas 
                        SET id_cliente=@id_cliente, id_seguro=@id_seguro, fecha_inicio=@fecha_inicio, fecha_fin=@fecha_fin,
                            estado=@estado, motivo_cancelacion=@motivo_cancelacion
                        WHERE numero_poliza=@numero_poliza";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@numero_poliza", p.numero_poliza);
                cmd.Parameters.AddWithValue("@id_cliente", p.id_cliente);
                cmd.Parameters.AddWithValue("@id_seguro", p.id_seguro);
                cmd.Parameters.AddWithValue("@fecha_inicio", p.fecha_inicio);
                cmd.Parameters.AddWithValue("@fecha_fin", p.fecha_fin);
                cmd.Parameters.AddWithValue("@estado", p.estado);
                cmd.Parameters.AddWithValue("@motivo_cancelacion", p.motivo_cancelacion);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ELIMINAR
        public void EliminarPoliza(string numeroPoliza)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"DELETE FROM polizas WHERE numero_poliza=@numero_poliza";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@numero_poliza", numeroPoliza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // BUSCAR
        public DataTable BuscarPoliza(string numeroPoliza)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT p.*, c.nombre AS nombre_cliente, c.apellidos AS apellidos_cliente, 
                               s.nombre AS nombre_seguro, s.tipo AS tipo_seguro
                        FROM polizas p
                        INNER JOIN clientes c ON p.id_cliente = c.id_cliente
                        INNER JOIN seguros s ON p.id_seguro = s.id_seguro
                        WHERE p.numero_poliza=@numero_poliza;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@numero_poliza", numeroPoliza);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // LISTAR TODAS
        public DataTable ListarPolizas()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT p.id_poliza, p.numero_poliza, c.nombre AS cliente, s.nombre AS seguro, 
                               p.fecha_inicio, p.fecha_fin, p.estado
                        FROM polizas p
                        INNER JOIN clientes c ON p.id_cliente = c.id_cliente
                        INNER JOIN seguros s ON p.id_seguro = s.id_seguro;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // ACTUALIZAR ESTADO (Cancelación / Renovación)
        public void ActualizarEstado(string numeroPoliza, string nuevoEstado, string motivo)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE polizas SET estado=@estado, motivo_cancelacion=@motivo WHERE numero_poliza=@numero_poliza";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@motivo", motivo);
                cmd.Parameters.AddWithValue("@numero_poliza", numeroPoliza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Listar por estado
        public DataTable ListarPorEstado(string estado)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                try
                {
                    string sql = @"SELECT 
                               p.id_poliza,
                               p.numero_poliza,
                               c.id_cliente,
                               c.nombre AS cliente,
                               s.id_seguro,
                               s.nombre_seguro AS seguro,
                               p.fecha_inicio,
                               p.fecha_fin,
                               p.estado,
                               p.motivo_cancelacion,
                               p.fecha_creacion
                           FROM polizas p
                           INNER JOIN clientes c ON p.id_cliente = c.id_cliente
                           INNER JOIN seguros s ON p.id_seguro = s.id_seguro
                           WHERE p.estado = @estado
                           ORDER BY p.fecha_creacion DESC;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar las pólizas por estado: " + ex.Message);
                }
            }

            return dt;
        }

    }
}
