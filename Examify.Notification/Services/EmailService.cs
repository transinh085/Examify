using Examify.Notification.Configs;
using MailKit.Net.Smtp;
using MimeKit;

namespace Examify.Notification.Services;

public class EmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(EmailSettings emailSettings)
    {
        _emailSettings = emailSettings;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
        emailMessage.To.Add(new MailboxAddress("", toEmail));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart("plain") { Text = message };

        using var client = new SmtpClient();
        await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, false);
        await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
        await client.SendAsync(emailMessage);
        await client.DisconnectAsync(true);
    }
}