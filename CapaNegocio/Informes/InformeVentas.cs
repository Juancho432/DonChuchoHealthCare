using Entidades;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Data;

namespace CapaNegocio.Informes
{
    public class InformeVentas
    {
        private readonly DataTable _data;
        private readonly Tipo_Seguro _tipo;
        private readonly Cliente _cliente;

        public InformeVentas(DataTable data, Tipo_Seguro tipo, Cliente cliente) 
        {
            _data = data;
            _tipo = tipo;
            _cliente = cliente;
        }

        public void Generar()
        {
            MasterPdf informe = new MasterPdf($"InformeVentas{DateTime.Now:dd-MM-yyyy}.pdf");
            informe.AddContent(new Paragraph($"INFORME DE VENTAS {DateTime.Now:dd-MM-yyyy}")
                .SetFontSize(20)
                .SetTextAlignment(TextAlignment.CENTER)
                .SimulateBold());
            informe.AddContent(new Paragraph($"Filtros aplicados: tipo({_tipo} - cliente({_cliente.nombre}))"));
            informe.AddContent(DataTable2Table.Convert(_data));
            informe.Close();
        }
    }
}
