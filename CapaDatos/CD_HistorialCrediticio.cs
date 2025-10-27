using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_HistorialCrediticio
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private string sql = "";

        //Insertar registro en historial
        public void InsertarHistorial(HistorialCrediticio h)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"INSERT INTO historial_crediticio (id_cliente, descripcion, calificacion, monto_adeudado, observaciones)
                        VALUES (@id_cliente, @descripcion, @calificacion, @monto_adeudado, @observaciones)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_cliente", h.id_cliente);
                cmd.Parameters.AddWithValue("@descripcion", h.descripcion);
                cmd.Parameters.AddWithValue("@calificacion", h.calificacion);
                cmd.Parameters.AddWithValue("@monto_adeudado", h.monto_adeudado);
                cmd.Parameters.AddWithValue("@observaciones", h.observaciones);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Actualizar registro
        public void ActualizarHistorial(HistorialCrediticio h)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE historial_crediticio 
                        SET descripcion=@descripcion, calificacion=@calificacion, 
                            monto_adeudado=@monto_adeudado, observaciones=@observaciones
                        WHERE id_historial=@id_historial";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_historial", h.id_historial);
                cmd.Parameters.AddWithValue("@descripcion", h.descripcion);
                cmd.Parameters.AddWithValue("@calificacion", h.calificacion);
                cmd.Parameters.AddWithValue("@monto_adeudado", h.monto_adeudado);
                cmd.Parameters.AddWithValue("@observaciones", h.observaciones);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Eliminar registro
        public void EliminarHistorial(int id_historial)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"DELETE FROM historial_crediticio WHERE id_historial=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id_historial);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Buscar registros por cliente
        public DataTable BuscarHistorialPorCliente(string id_cliente)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM historial_crediticio 
                        WHERE id_cliente=@id_cliente
                        ORDER BY fecha_registro DESC";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Listar todo el historial
        public DataTable ListarHistorial()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT h.*, CONCAT(c.nombre, ' ', c.apellidos) AS cliente
                        FROM historial_crediticio h
                        INNER JOIN clientes c ON h.id_cliente = c.id_cliente
                        ORDER BY h.fecha_registro DESC";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;

        }
    }
}
