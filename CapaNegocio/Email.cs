
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;


namespace CapaNegocio
{
    public class Email
    {
        public static bool ComprobarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patron, RegexOptions.IgnoreCase);
        }

        // Certificados, Extractos, Facturas, Reportes, Recordatorio de pago
        public static int EnviarEmail(string destino, string asunto, string mensaje, string adjunto)
        {
            MailMessage mail_handler = new MailMessage
            {
                From = new MailAddress("noreply@DonChuchoHealthCare.com", "No Reply"),
                Subject = asunto,
                Body = mensaje,
                IsBodyHtml = true
            }; 

            mail_handler.To.Add(destino);

            SmtpClient smtp_client = new SmtpClient();
            SmtpClient smtp = new SmtpClient();
            smtp.Send(mail_handler);
            return 0;
        }
    }
}
