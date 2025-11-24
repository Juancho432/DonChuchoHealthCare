using iText.Kernel.Colors;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Data;

namespace CapaNegocio.Informes
{
    public static class DataTable2Table
    {

        public static Table Convert(DataTable dt)
            {
                // Crear tabla con tantas columnas como el DataTable
                Table tabla = new Table(dt.Columns.Count, true);

                // ===== CABECERA =====
                foreach (DataColumn col in dt.Columns)
                {
                    Cell celdaHeader = new Cell()
                        .Add(new Paragraph(col.ColumnName))
                        .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                        .SimulateBold()
                        .SetTextAlignment(TextAlignment.CENTER);

                    tabla.AddHeaderCell(celdaHeader);
                }

                // ===== CONTENIDO =====
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        tabla.AddCell(
                            new Cell()
                                .Add(new Paragraph(item?.ToString() ?? ""))
                                .SetTextAlignment(TextAlignment.LEFT)
                        );
                    }
                }

                return tabla;
            }
        }
}
