using Microsoft.Extensions.Logging;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using YdyoOBS.Application.Interfaces;

namespace YdyoOBS.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string from, string subject, string body)
        {
            var emailClient = new SmtpClient("lcoalhost");
            var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            message.To.Add(new MailAddress(to));
            await emailClient.SendMailAsync(message);
            _logger.LogWarning($"{from} mail adresinden {to} mail adresine mail gönderldi. Gönderilen Mail : {subject}");
        }
    }
}
