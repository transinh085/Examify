using Examify.Notification.Mail;

namespace Examify.Notification.Infrastructure.Email;

public class MailService : IMailService
{
    public Task SendEmailAsync(string toEmail, string subject, string message)
    {
        throw new NotImplementedException();
    }
}