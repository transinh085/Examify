namespace Examify.Notification.Infrastructure.Mail;

public class MailOptions
{
    public string SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}