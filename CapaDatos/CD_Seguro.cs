using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace CapaDatos
{
    public class CD_Seguro
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private string sql = "";

        private Seguro ConvertirFilaASeguro(DataRow row)
        {
            // tipo
            string tipoStr = row["tipo"] == DBNull.Value ? "Otro" : row["tipo"].ToString();
            if (!Enum.TryParse(tipoStr, ignoreCase: true, out Tipo_Seguro tipoEnum))
                tipoEnum = Tipo_Seguro.Otro;

            // estado
            string estadoStr = row["estado"] == DBNull.Value ? "Activo" : row["estado"].ToString();
            if (!Enum.TryParse(estadoStr, ignoreCase: true, out Estado_Seguro estadoEnum))
                estadoEnum = Estado_Seguro.Activo;

            return new Seguro
            {
                id_seguro = Convert.ToInt32(row["id_seguro"]),
                nombre = row["nombre"]?.ToString() ?? "",
                tipo_seguro = tipoEnum,
                cobertura = row["cobertura"]?.ToString() ?? "",
                costo = row["costo"] == DBNull.Value ? 0 : Convert.ToDecimal(row["costo"]),
                duracion_meses = row["duracion_meses"] == DBNull.Value ? 0 : Convert.ToInt32(row["duracion_meses"]),
                beneficios = row["beneficios"]?.ToString() ?? "",
                exclusiones = row["exclusiones"]?.ToString() ?? "",
                condiciones = row["condiciones"]?.ToString() ?? "",
                id_aseguradora = row["id_aseguradora"] == DBNull.Value ? 0 : Convert.ToInt32(row["id_aseguradora"]),
                estado = estadoEnum
            };
        }



        // Insertar Seguro 
        public bool InsertarSeguro(Seguro s)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(cadena))
                {
                    sql = @"INSERT INTO seguros 
                            (nombre, tipo, cobertura, costo, duracion_meses, beneficios, exclusiones, condiciones, id_aseguradora, estado)
                            VALUES (@nombre, @tipo, @cobertura, @costo, @duracion, @beneficios, @exclusiones, @condiciones, @idAseguradora, @estado)";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(s.nombre) ? (object)DBNull.Value : s.nombre);
                    cmd.Parameters.AddWithValue("@tipo", s.tipo_seguro.ToString());
                    cmd.Parameters.AddWithValue("@cobertura", string.IsNullOrEmpty(s.cobertura) ? (object)DBNull.Value : s.cobertura);
                    cmd.Parameters.AddWithValue("@costo", s.costo);
                    cmd.Parameters.AddWithValue("@duracion", s.duracion_meses);
                    cmd.Parameters.AddWithValue("@beneficios", string.IsNullOrEmpty(s.beneficios) ? (object)DBNull.Value : s.beneficios);
                    cmd.Parameters.AddWithValue("@exclusiones", string.IsNullOrEmpty(s.exclusiones) ? (object)DBNull.Value : s.exclusiones);
                    cmd.Parameters.AddWithValue("@condiciones", string.IsNullOrEmpty(s.condiciones) ? (object)DBNull.Value : s.condiciones);
                    cmd.Parameters.AddWithValue("@idAseguradora", s.id_aseguradora == 0 ? (object)DBNull.Value : s.id_aseguradora);
                    cmd.Parameters.AddWithValue("@estado", s.estado.ToString());

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar seguro: " + ex.Message, ex);
            }
        }


        // Actualizar Seguro 
        public bool ActualizarSeguro(Seguro s)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(cadena))
                {
                    sql = @"UPDATE seguros 
                            SET nombre=@nombre, tipo=@tipo, cobertura=@cobertura, costo=@costo, duracion_meses=@duracion,
                                beneficios=@beneficios, exclusiones=@exclusiones, condiciones=@condiciones,
                                id_aseguradora=@idAseguradora, estado=@estado
                            WHERE id_seguro=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(s.nombre) ? (object)DBNull.Value : s.nombre);
                    cmd.Parameters.AddWithValue("@tipo", s.tipo_seguro.ToString());
                    cmd.Parameters.AddWithValue("@cobertura", string.IsNullOrEmpty(s.cobertura) ? (object)DBNull.Value : s.cobertura);
                    cmd.Parameters.AddWithValue("@costo", s.costo);
                    cmd.Parameters.AddWithValue("@duracion", s.duracion_meses);
                    cmd.Parameters.AddWithValue("@beneficios", string.IsNullOrEmpty(s.beneficios) ? (object)DBNull.Value : s.beneficios);
                    cmd.Parameters.AddWithValue("@exclusiones", string.IsNullOrEmpty(s.exclusiones) ? (object)DBNull.Value : s.exclusiones);
                    cmd.Parameters.AddWithValue("@condiciones", string.IsNullOrEmpty(s.condiciones) ? (object)DBNull.Value : s.condiciones);
                    cmd.Parameters.AddWithValue("@idAseguradora", s.id_aseguradora == 0 ? (object)DBNull.Value : s.id_aseguradora);
                    cmd.Parameters.AddWithValue("@estado", s.estado.ToString());

                    // Parámetro del WHERE que faltaba
                    cmd.Parameters.AddWithValue("@id", s.id_seguro);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar seguro: " + ex.Message, ex);
            }
        }


        // Eliminar Seguro 
        public bool EliminarSeguro(int idSeguro)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE seguros SET estado = 'Inactivo' WHERE id_seguro = @id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idSeguro);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Buscar Seguro por ID 
        public Seguro BuscarSeguro(int idSeguro)
        {
            var dt = new DataTable();

            using (var con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM seguros WHERE id_seguro=@id";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idSeguro);

                new MySqlDataAdapter(cmd).Fill(dt);
            }

            if (dt.Rows.Count == 0) return default;

            return ConvertirFilaASeguro(dt.Rows[0]);
        }


        // Listar todos los Seguros 
        public DataTable ListarSeguros()
        {
            var dt = new DataTable();
            using (var con = new MySqlConnection(cadena))
            {
                sql = @"SELECT id_seguro, nombre, tipo, cobertura, costo, duracion_meses, estado
                        FROM seguros ORDER BY nombre ASC";

                new MySqlDataAdapter(sql, con).Fill(dt);
            }
            return dt;
        }

        // Búsqueda avanzada
        public DataTable BuscarSegurosAvanzado(string tipo, string cobertura, string nombreAseguradora)
        {
            var dt = new DataTable();

            using (var con = new MySqlConnection(cadena))
            {
                sql = @"SELECT s.*, a.nombre AS aseguradora
                        FROM seguros s
                        LEFT JOIN aseguradoras a ON a.id_aseguradora = s.id_aseguradora
                        WHERE (@tipo = '' OR s.tipo LIKE CONCAT('%', @tipo, '%'))
                          AND (@cobertura = '' OR s.cobertura LIKE CONCAT('%', @cobertura, '%'))
                          AND (@aseguradora = '' OR a.nombre LIKE CONCAT('%', @aseguradora, '%'));";

                var cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@tipo", tipo ?? "");
                cmd.Parameters.AddWithValue("@cobertura", cobertura ?? "");
                cmd.Parameters.AddWithValue("@aseguradora", nombreAseguradora ?? "");

                new MySqlDataAdapter(cmd).Fill(dt);
            }

            return dt;
        }
    }
}
