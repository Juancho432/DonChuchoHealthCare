using Entidades;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace CapaNegocio.Informes
{
    public class ReciboPago
    {
        private readonly Pago _pago;
        private readonly Cliente _cliente;
        private readonly Poliza _poliza;
        private readonly Seguro _seguro;

        public ReciboPago(Pago data)
        {
            _pago = data;
            CN_Cliente objCN_Cliente = new CN_Cliente();
            _cliente = objCN_Cliente.BuscarCliente(_pago.id_cliente);
            CN_Poliza objCN_Poliza = new CN_Poliza();
            _poliza = objCN_Poliza.BuscarPoliza(_pago.id_poliza.ToString());
            CN_Seguro objCN_Seguro = new CN_Seguro();
            _seguro = objCN_Seguro.BuscarSeguro(_poliza.id_seguro);
        }

        public void GenerarRecibo()
        {
            MasterPdf master = new MasterPdf($"Recibo{_pago.id_pago}.pdf");
            master.AddContent(new Paragraph($"RECIBO DE PAGO N°{_pago.id_pago}")
                .SetFontSize(20)
                .SetTextAlignment(TextAlignment.CENTER)
                .SimulateBold());

            Table datosCliente = new Table(2).UseAllAvailableWidth();

            datosCliente.AddCell("Cliente");
            datosCliente.AddCell(_cliente.nombre);
            datosCliente.AddCell("Documento");
            datosCliente.AddCell(_cliente.id_cliente);
            datosCliente.AddCell("Fecha de Pago");
            datosCliente.AddCell(_pago.fecha_pago.ToString("dd/MM/yyyy"));
            datosCliente.AddCell("Metodo de Pago");
            datosCliente.AddCell(_pago.forma_pago.ToString());

            master.AddContent(new Paragraph("DETALLE SERVICIOS")
                .SetFontSize(20)
                .SetTextAlignment(TextAlignment.CENTER)
                .SimulateBold());

            Table detalleServicios = new Table(4).UseAllAvailableWidth();
            detalleServicios.AddHeaderCell("Item");
            detalleServicios.AddHeaderCell("Descripcion");
            detalleServicios.AddHeaderCell("Poliza N°");
            detalleServicios.AddHeaderCell("Costo");

            detalleServicios.AddCell("1");
            detalleServicios.AddCell(_seguro.nombre);
            detalleServicios.AddCell(_poliza.id_poliza.ToString());
            detalleServicios.AddCell(_seguro.costo.ToString());
            master.AddContent(datosCliente);

            master.Close();
        }
    }
}
