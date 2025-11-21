using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using Entidades;

namespace CapaDatos
{
    public class CD_Usuario
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private string sql = "";

        // Insertar nuevo usuario
        public bool InsertarUsuario(Usuario u)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"INSERT INTO usuarios 
                        (nombre_usuario, contrasena, rol, nombre, apellidos, correo, estado, fecha_creacion)
                        VALUES (@nombre_usuario, @contrasena, @rol, @nombre, @apellidos, @correo, @estado, @fecha_creacion)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre_usuario", u.usuario);
                cmd.Parameters.AddWithValue("@contrasena", u.contraseña);
                cmd.Parameters.AddWithValue("@rol", u.rol.ToString());
                cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(u.nombre) ? (object)DBNull.Value : u.nombre);
                cmd.Parameters.AddWithValue("@apellidos", string.IsNullOrEmpty(u.apellidos) ? (object)DBNull.Value : u.apellidos);
                cmd.Parameters.AddWithValue("@correo", string.IsNullOrEmpty(u.correo) ? (object)DBNull.Value : u.correo);
                cmd.Parameters.AddWithValue("@estado", u.estado.ToString());
                cmd.Parameters.AddWithValue("@fecha_creacion", u.fecha_creacion == DateTime.MinValue ? (object)DBNull.Value : u.fecha_creacion);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Validar inicio de sesión (devuelve Usuario si válido, sino null)
        public Usuario? ValidarUsuario(string nombreUsuario, string contrasena)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM usuarios 
                        WHERE nombre_usuario = @nombre_usuario 
                          AND contrasena = @contrasena
                          AND estado = 'Activo'";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                con.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Usuario u = new Usuario
                        {
                            id_usuario = dr["id_usuario"] == DBNull.Value ? 0 : Convert.ToInt32(dr["id_usuario"]),
                            usuario = dr["nombre_usuario"] == DBNull.Value ? string.Empty : dr["nombre_usuario"].ToString(),
                            contraseña = dr["contrasena"] == DBNull.Value ? string.Empty : dr["contrasena"].ToString(),
                            rol = dr["rol"] == DBNull.Value ? Rol_Usuario.Asesor : (Rol_Usuario)Enum.Parse(typeof(Rol_Usuario), dr["rol"].ToString()),
                            nombre = dr["nombre"] == DBNull.Value ? string.Empty : dr["nombre"].ToString(),
                            apellidos = dr["apellidos"] == DBNull.Value ? string.Empty : dr["apellidos"].ToString(),
                            correo = dr["correo"] == DBNull.Value ? string.Empty : dr["correo"].ToString(),
                            estado = dr["estado"] == DBNull.Value ? Estado_Usuario.Activo : (Estado_Usuario)Enum.Parse(typeof(Estado_Usuario), dr["estado"].ToString()),
                            fecha_creacion = dr["fecha_creacion"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["fecha_creacion"])
                        };
                        return u;
                    }
                }
            }
            return null;
        }

        // Listar todos los usuarios
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"SELECT * FROM usuarios ORDER BY fecha_creacion DESC";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Usuario u = new Usuario
                        {
                            id_usuario = dr["id_usuario"] == DBNull.Value ? 0 : Convert.ToInt32(dr["id_usuario"]),
                            usuario = dr["nombre_usuario"] == DBNull.Value ? string.Empty : dr["nombre_usuario"].ToString(),
                            contraseña = dr["contrasena"] == DBNull.Value ? string.Empty : dr["contrasena"].ToString(),
                            rol = dr["rol"] == DBNull.Value ? Rol_Usuario.Asesor : (Rol_Usuario)Enum.Parse(typeof(Rol_Usuario), dr["rol"].ToString()),
                            nombre = dr["nombre"] == DBNull.Value ? string.Empty : dr["nombre"].ToString(),
                            apellidos = dr["apellidos"] == DBNull.Value ? string.Empty : dr["apellidos"].ToString(),
                            correo = dr["correo"] == DBNull.Value ? string.Empty : dr["correo"].ToString(),
                            estado = dr["estado"] == DBNull.Value ? Estado_Usuario.Activo : (Estado_Usuario)Enum.Parse(typeof(Estado_Usuario), dr["estado"].ToString()),
                            fecha_creacion = dr["fecha_creacion"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["fecha_creacion"])
                        };
                        lista.Add(u);
                    }
                }
            }

            return lista;
        }

        // Actualizar usuario
        public bool ActualizarUsuario(Usuario u)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE usuarios SET 
                        nombre_usuario = @nombre_usuario,
                        contrasena = @contrasena,
                        rol = @rol,
                        nombre = @nombre,
                        apellidos = @apellidos,
                        correo = @correo,
                        estado = @estado
                        WHERE id_usuario = @id_usuario";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre_usuario", u.usuario);
                cmd.Parameters.AddWithValue("@contrasena", u.contraseña);
                cmd.Parameters.AddWithValue("@rol", u.rol.ToString());
                cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(u.nombre) ? (object)DBNull.Value : u.nombre);
                cmd.Parameters.AddWithValue("@apellidos", string.IsNullOrEmpty(u.apellidos) ? (object)DBNull.Value : u.apellidos);
                cmd.Parameters.AddWithValue("@correo", string.IsNullOrEmpty(u.correo) ? (object)DBNull.Value : u.correo);
                cmd.Parameters.AddWithValue("@estado", u.estado.ToString());
                cmd.Parameters.AddWithValue("@id_usuario", u.id_usuario);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cambiar estado (activar / desactivar)
        public bool CambiarEstado(int id_usuario, Estado_Usuario nuevoEstado)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"UPDATE usuarios SET estado = @estado WHERE id_usuario = @id_usuario";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@estado", nuevoEstado.ToString());
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Eliminar usuario
        public bool EliminarUsuario(int id_usuario)
        {
            using (MySqlConnection con = new MySqlConnection(cadena))
            {
                sql = @"DELETE FROM usuarios WHERE id_usuario = @id_usuario";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //Verificar si existen admins
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
