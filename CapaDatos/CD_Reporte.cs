using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace CapaDatos
{
    public class CD_Reporte
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private string sql = "";

        //Ventas (seguros vendidos) por tipo de seguro
        public DataTable ReporteVentasPorTipoSeguro(Tipo_Seguro tipo_seguron)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                sql = @"
                    SELECT s.tipo_seguro AS Tipo,
                           COUNT(p.id_poliza) AS TotalPolizas,
                           SUM(pg.monto) AS TotalPagos
                    FROM poliza p
                    INNER JOIN seguro s ON p.id_seguro = s.id_seguro
                    INNER JOIN pago pg ON p.id_poliza = pg.id_poliza
                    WHERE pg.fecha_pago BETWEEN @inicio AND @fin
                    GROUP BY s.tipo_seguro;
                ";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@tipo_seguro", tipo_seguron);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Pagos atrasados (según fecha vencimiento vs fecha pago)
        public DataTable ReportePagosAtrasados()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                sql = @"
                    SELECT c.nombre AS Cliente,
                           s.tipo_seguro AS TipoSeguro,
                           pg.fecha_pago,
                           pg.fecha_vencimiento,
                           DATEDIFF(pg.fecha_pago, pg.fecha_vencimiento) AS DiasRetraso
                    FROM pago pg
                    INNER JOIN poliza p ON pg.id_poliza = p.id_poliza
                    INNER JOIN cliente c ON p.id_cliente = c.id_cliente
                    INNER JOIN seguro s ON p.id_seguro = s.id_seguro
                    WHERE pg.fecha_pago > pg.fecha_vencimiento;
                ";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Seguros más vendidos
        public DataTable ReporteSegurosMasVendidos()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                sql = @"
                    SELECT s.tipo_seguro AS TipoSeguro,
                           COUNT(p.id_poliza) AS CantidadVendida
                    FROM poliza p
                    INNER JOIN seguro s ON p.id_seguro = s.id_seguro
                    GROUP BY s.tipo_seguro
                    ORDER BY CantidadVendida DESC;
                ";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Renovaciones y cancelaciones
        public DataTable ReporteEstadosPolizas()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                sql = @"
                    SELECT estado AS EstadoPoliza,
                           COUNT(*) AS Total
                    FROM poliza
                    GROUP BY estado;
                ";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
