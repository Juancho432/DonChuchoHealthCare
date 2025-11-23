using System;
using System.Data;
using System.Web.Services;
using MySql.Data.MySqlClient;

namespace WSAseguradora
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class AseguradoraWS : WebService
    {
        string cadena = "Server=localhost;Database=seguros;Uid=root;Pwd=;";

        [WebMethod]
        public DataTable ObtenerPolizasPorAseguradora(int idAseguradora)
        {
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                string sql = @"SELECT p.id_poliza, c.nombre AS cliente, s.nombre AS seguro, p.fecha_inicio, p.fecha_fin, p.estado
                               FROM polizas p
                               INNER JOIN clientes c ON p.id_cliente = c.id_cliente
                               INNER JOIN seguros s ON p.id_seguro = s.id_seguro
                               WHERE s.id_aseguradora = @ids";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@ids", idAseguradora);

                DataTable dt = new DataTable("Polizas");
                da.Fill(dt);
                return dt;
            }
        }

        [WebMethod]
        public DataTable ObtenerClientesPorAseguradora(int idAseguradora)
        {
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                string sql = @"SELECT DISTINCT c.id_cliente, c.nombre, c.apellidos, c.cedula, c.telefono
                               FROM polizas p
                               INNER JOIN clientes c ON p.id_cliente = c.id_cliente
                               INNER JOIN seguros s ON p.id_seguro = s.id_seguro
                               WHERE s.id_aseguradora = @ids";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@ids", idAseguradora);

                DataTable dt = new DataTable("Clientes");
                da.Fill(dt);
                return dt;
            }
        }

        [WebMethod]
        public DataTable ObtenerPolizasPorCliente(int idCliente)
        {
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                string sql = @"SELECT p.id_poliza, s.nombre AS seguro, s.tipo, p.fecha_inicio, p.fecha_fin, p.estado
                               FROM polizas p
                               INNER JOIN seguros s ON p.id_seguro = s.id_seguro
                               WHERE p.id_cliente = @idc";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@idc", idCliente);

                DataTable dt = new DataTable("PolizasCliente");
                da.Fill(dt);
                return dt;
            }
        }
    }
}
