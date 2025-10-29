using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

using CapaNegocio;

namespace CapaDatos
{
    public class CD_Aseguradora
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private string sql = "";

        //Insertar Aseguradora
        public void InsertarAseguradora(Aseguradora a)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"INSERT INTO aseguradoras (nombre, direccion, telefono, correo, sitio_web)
                        VALUES (@nombre, @direccion, @telefono, @correo, @sitio_web)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre", a.nombre);
                cmd.Parameters.AddWithValue("@direccion", a.direccion);
                cmd.Parameters.AddWithValue("@telefono", a.telefono);
                cmd.Parameters.AddWithValue("@correo", a.correo);
                cmd.Parameters.AddWithValue("@sitio_web", a.sitio_web);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Actualizar Aseguradora
        public void ActualizarAseguradora(Aseguradora a)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE aseguradoras 
                        SET nombre=@nombre, direccion=@direccion, telefono=@telefono, 
                            correo=@correo, sitio_web=@sitio_web
                        WHERE id_aseguradora=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", a.id_aseguradora);
                cmd.Parameters.AddWithValue("@nombre", a.nombre);
                cmd.Parameters.AddWithValue("@direccion", a.direccion);
                cmd.Parameters.AddWithValue("@telefono", a.telefono);
                cmd.Parameters.AddWithValue("@correo", a.correo);
                cmd.Parameters.AddWithValue("@sitio_web", a.sitio_web);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Eliminar Aseguradora
        public void EliminarAseguradora(int idAseguradora)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"DELETE FROM aseguradoras WHERE id_aseguradora=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idAseguradora);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Buscar Aseguradora por ID
        public DataTable BuscarAseguradora(int idAseguradora)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM aseguradoras WHERE id_aseguradora=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idAseguradora);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Buscar Aseguradora por nombre o correo
        public DataTable BuscarAseguradoraAvanzado(string nombre, string correo)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM aseguradoras
                        WHERE (@nombre IS NULL OR nombre LIKE CONCAT('%', @nombre, '%'))
                          AND (@correo IS NULL OR correo LIKE CONCAT('%', @correo, '%'))
                        ORDER BY nombre ASC";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(nombre) ? null : nombre);
                cmd.Parameters.AddWithValue("@correo", string.IsNullOrEmpty(correo) ? null : correo);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Listar todas las Aseguradoras
        public DataTable ListarAseguradoras()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM aseguradoras ORDER BY nombre ASC";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
