namespace Examify.Notification.Infrastructure.Email;

public class EmailOptions
{
    public string SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}