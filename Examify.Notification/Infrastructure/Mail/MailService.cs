using System.Net;
using System.Net.Mail;
using Examify.Notification.Mail;
using Microsoft.Extensions.Options;

namespace Examify.Notification.Infrastructure.Mail;

public class MailService(IOptions<MailOptions> mailOptions) : IMailService
{
    private readonly MailOptions _mailOptions = mailOptions.Value;

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var smtpClient = new SmtpClient(_mailOptions.SmtpServer)
        {
            Port = _mailOptions.SmtpPort,
            Credentials = new NetworkCredential(_mailOptions.Username, _mailOptions.Password),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage()
        {
            From = new MailAddress(_mailOptions.SenderEmail, _mailOptions.SenderName),
            Subject = subject,
            Body = message,
            IsBodyHtml = true,
        };

        mailMessage.To.Add(toEmail);

        await smtpClient.SendMailAsync(mailMessage);
    }
}