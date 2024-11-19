using Examify.Events;
using Examify.Notification.Mail;
using MassTransit;

namespace Examify.Notification.Consumers;

public class UserPasswordResetConsumer(ILogger<UserPasswordResetConsumer> logger, IMailService mailService)
    : IConsumer<UserPasswordResetEvent>
{
    public async Task Consume(ConsumeContext<UserPasswordResetEvent> context)
    {
        logger.LogInformation("UserPasswordResetConsumer received: {UserId}", context.Message.UserId);
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure", "Templates", "PasswordResetEmailTemplate.html");
        var templateContent = await File.ReadAllTextAsync(templatePath);
        var message = templateContent.Replace("{{ResetLink}}", context.Message.ResetLink);

        await mailService.SendEmailAsync(context.Message.Email, "Password Reset", message);
    }
}