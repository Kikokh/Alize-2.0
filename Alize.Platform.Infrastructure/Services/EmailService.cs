using Alize.Platform.Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Alize.Platform.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _emailSettings;

        public EmailService(IOptions<EmailOptions> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmail(string address, string subject, string body, bool isHtml = false)
        {
            var username = _emailSettings.Username;
            var password = _emailSettings.Password;

            var host = _emailSettings.Host;
            var port = _emailSettings.Port;

            var mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.SenderEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = isHtml
            };

            mail.To.Add(address);

            using var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            await client.SendMailAsync(mail);
        }
    }
}
