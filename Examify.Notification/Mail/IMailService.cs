namespace Examify.Notification.Mail;

public interface IMailService
{
    Task SendEmailAsync(string toEmail, string subject, string message);
}