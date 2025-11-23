using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Drawing.Imaging;

namespace CapaNegocio.Informes
{
    public class MasterPdf
    {
        private const string _telefono = "3243070697";
        private const string _direccion = "Poblado";
        private const string _web = "DonChuchoHealthCare.com";

        private readonly DateTime _fechaGeneracion;
        private readonly PdfDocument _pdf;
        private readonly Document _doc;

        public MasterPdf(string rutaSalida)
        {
            _fechaGeneracion = DateTime.Now;

            var writer = new PdfWriter(rutaSalida);
            _pdf = new PdfDocument(writer);
            _doc = new Document(_pdf, PageSize.LETTER);

            AgregarNuevaPagina(); // Página inicial con header/footer
        }

        public void AddContent(IBlockElement contenido)
        {
            _doc.Add(contenido);
        }


        public void Close()
        {
            _doc.Close();
        }

        public void AgregarNuevaPagina()
        {
            _pdf.AddNewPage();
            DibujarEncabezado();
            DibujarPiePagina();
        }

        private void DibujarEncabezado()
        {
            float width = _pdf.GetDefaultPageSize().GetWidth();
            float top = _pdf.GetDefaultPageSize().GetTop() - 20;
            int pageNumber = _pdf.GetNumberOfPages();

            // Convertir bitmap de Resources a bytes
            byte[] bytesLogo;
            using (var ms = new MemoryStream())
            {
                Properties.Resources.Logo.Save(ms, ImageFormat.Png);
                bytesLogo = ms.ToArray();
            }

            ImageData img = ImageDataFactory.Create(bytesLogo);
            Image logo = new Image(img).SetHeight(50);

            // Logo izquierda
            Paragraph pLogo = new Paragraph().Add(logo);

            _doc.ShowTextAligned(pLogo,
                60, top,
                pageNumber,
                TextAlignment.LEFT,
                VerticalAlignment.TOP,
                0);

            // Info derecha
            string info = "Tel: " + _telefono + "\n" +
                          _direccion + "\n" +
                          _web;

            Paragraph pInfo = new Paragraph(info)
                .SetFontSize(10)
                .SetTextAlignment(TextAlignment.RIGHT);

            _doc.ShowTextAligned(pInfo,
                width - 60, top,
                pageNumber,
                TextAlignment.RIGHT,
                VerticalAlignment.TOP,
                0);
        }

        private void DibujarPiePagina()
        {
            float width = _pdf.GetDefaultPageSize().GetWidth();
            float bottom = 40;
            int pageNumber = _pdf.GetNumberOfPages();

            // Frase
            Paragraph frase = new Paragraph("Cuidamos lo que más valoras")
                .SetFontSize(11)
                .SetTextAlignment(TextAlignment.CENTER);

            _doc.ShowTextAligned(frase,
                width / 2, bottom + 15,
                pageNumber,
                TextAlignment.CENTER,
                VerticalAlignment.BOTTOM,
                0);

            // Fecha
            Paragraph fecha = new Paragraph(_fechaGeneracion.ToString("dd/MM/yyyy HH:mm"))
                .SetFontSize(9)
                .SetTextAlignment(TextAlignment.CENTER);

            _doc.ShowTextAligned(fecha,
                width / 2, bottom,
                pageNumber,
                TextAlignment.CENTER,
                VerticalAlignment.BOTTOM,
                0);
        }
    }
}
