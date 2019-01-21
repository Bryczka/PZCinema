using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AdminCinemaApp
{
    public class SendEmail
    {
        public void Send(string subject, string body, string email)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("kinopz.wat@gmail.com");
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            mailMessage.To.Add(email);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("kinopz.wat@gmail.com", "projekt428")
            };

            smtp.SendMailAsync(mailMessage);
        }

    }
}
