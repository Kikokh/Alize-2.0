using System.Net.Mail;

namespace Alize.Platform.Infrastructure
{
    public interface IEmailService
    {
        Task SendEmail(string address, string subject, string body, bool isHtml = false);
    }
}