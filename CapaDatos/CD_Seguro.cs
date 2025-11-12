using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using Entidades;

namespace CapaDatos
{
    public class CD_Seguro
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private string sql = "";

        //Insertar Seguro
        public void InsertarSeguro(Seguro s)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"INSERT INTO seguros 
                        (nombre, tipo, cobertura, costo, duracion_meses, beneficios, exclusiones, condiciones, id_aseguradora, estado)
                        VALUES (@nombre, @tipo, @cobertura, @costo, @duracion, @beneficios, @exclusiones, @condiciones, @idAseguradora, @estado)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre", s.nombre);
                cmd.Parameters.AddWithValue("@tipo", s.tipo_seguro);
                cmd.Parameters.AddWithValue("@cobertura", s.cobertura);
                cmd.Parameters.AddWithValue("@costo", s.costo);
                cmd.Parameters.AddWithValue("@duracion", s.duracion_meses);
                cmd.Parameters.AddWithValue("@beneficios", s.beneficios);
                cmd.Parameters.AddWithValue("@exclusiones", s.exclusiones);
                cmd.Parameters.AddWithValue("@condiciones", s.condiciones);
                cmd.Parameters.AddWithValue("@idAseguradora", s.id_aseguradora);
                cmd.Parameters.AddWithValue("@estado", s.estado);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Actualizar Seguro
        public void ActualizarSeguro(Seguro s)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE seguros 
                        SET nombre=@nombre, tipo=@tipo, cobertura=@cobertura, costo=@costo, duracion_meses=@duracion,
                            beneficios=@beneficios, exclusiones=@exclusiones, condiciones=@condiciones,
                            id_aseguradora=@idAseguradora, estado=@estado
                        WHERE id_seguro=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre", s.nombre);
                cmd.Parameters.AddWithValue("@tipo", s.tipo_seguro);
                cmd.Parameters.AddWithValue("@cobertura", s.cobertura);
                cmd.Parameters.AddWithValue("@costo", s.costo);
                cmd.Parameters.AddWithValue("@duracion", s.duracion_meses);
                cmd.Parameters.AddWithValue("@beneficios", s.beneficios);
                cmd.Parameters.AddWithValue("@exclusiones", s.exclusiones);
                cmd.Parameters.AddWithValue("@condiciones", s.condiciones);
                cmd.Parameters.AddWithValue("@idAseguradora", s.id_aseguradora);
                cmd.Parameters.AddWithValue("@estado", s.estado);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Eliminar Seguro
        public void EliminarSeguro(int idSeguro)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"DELETE FROM seguros WHERE id_seguro=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idSeguro);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Buscar Seguro por ID
        public DataTable BuscarSeguro(int idSeguro)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT s.*, a.nombre AS nombre_aseguradora
                        FROM seguros s
                        LEFT JOIN aseguradoras a ON s.id_aseguradora = a.id_aseguradora
                        WHERE s.id_seguro = @id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idSeguro);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Listar todos los Seguros
        public DataTable ListarSeguros()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT s.id_seguro, s.nombre, s.tipo, s.cobertura, s.costo, s.duracion_meses,
                               a.nombre AS aseguradora, s.estado
                        FROM seguros s
                        LEFT JOIN aseguradoras a ON s.id_aseguradora = a.id_aseguradora
                        ORDER BY s.nombre ASC";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Búsqueda avanzada (por tipo, cobertura o aseguradora)
        public DataTable BuscarSegurosAvanzado(string tipo, string cobertura, string nombreAseguradora)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT s.id_seguro, s.nombre, s.tipo, s.cobertura, s.costo, s.duracion_meses,
                               a.nombre AS aseguradora, s.estado
                        FROM seguros s
                        LEFT JOIN aseguradoras a ON s.id_aseguradora = a.id_aseguradora
                        WHERE (@tipo IS NULL OR s.tipo LIKE CONCAT('%', @tipo, '%'))
                          AND (@cobertura IS NULL OR s.cobertura LIKE CONCAT('%', @cobertura, '%'))
                          AND (@nombreAseguradora IS NULL OR a.nombre LIKE CONCAT('%', @nombreAseguradora, '%'))
                        ORDER BY s.nombre ASC";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tipo", string.IsNullOrEmpty(tipo) ? null : tipo);
                cmd.Parameters.AddWithValue("@cobertura", string.IsNullOrEmpty(cobertura) ? null : cobertura);
                cmd.Parameters.AddWithValue("@nombreAseguradora", string.IsNullOrEmpty(nombreAseguradora) ? null : nombreAseguradora);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
