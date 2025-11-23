using Entidades;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Informes
{
    public class CertificadoPoliza
    {
        private readonly Poliza _poliza;
        private readonly Cliente _cliente;
        private readonly Seguro _seguro;

        public CertificadoPoliza(Poliza data)
        {
            _poliza = data;
            CN_Cliente objCN_Cliente = new CN_Cliente();
            _cliente = objCN_Cliente.BuscarCliente(_poliza.id_cliente);
            CN_Seguro objCN_Seguro = new CN_Seguro();
            _seguro = objCN_Seguro.BuscarSeguro(_poliza.id_seguro);
        }

        public void Generar()
        {
            MasterPdf master = new MasterPdf($"CertificadoPoliza{_poliza.id_poliza}.pdf");
            master.AddContent(new Paragraph($"CERTIFICADO DE POLIZA N°{_poliza.numero_poliza}")
                .SetFontSize(20)
                .SetTextAlignment(TextAlignment.CENTER)
                .SimulateBold());
            master.AddContent(new Paragraph("" +
                "DonChuchoHealtCare CERTIFICA que los servicios descritos en este documento se encuentran en estado activo y contratados " + 
                $"por el/la SEÑOR/A {_cliente.nombre} identificado con {_cliente.tipo_documento.ToString()} {_cliente.id_cliente} " + 
                $"a fecha de {DateTime.Now:dd-MM-yyyy}"));

            Table servicios = new Table(4).UseAllAvailableWidth();
            servicios.AddHeaderCell("Poliza N°");
            servicios.AddHeaderCell("Descripcion");
            servicios.AddHeaderCell("Fecha de Inicio");
            servicios.AddHeaderCell("Fecha de Fin");

            servicios.AddCell(_poliza.numero_poliza.ToString());
            servicios.AddCell(_seguro.nombre);
            servicios.AddCell(_poliza.fecha_inicio.ToString("dd-MM-yyyy"));
            servicios.AddCell(_poliza.fecha_fin.ToString("dd-MM-yyyy"));
            master.AddContent(servicios);
            master.Close();
        }
    }
}
