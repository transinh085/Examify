using Examify.Events;
using Examify.Notification.Mail;
using MassTransit;

namespace Examify.Notification.Consumers;

public class UserVerificationEmailConsumer(ILogger<UserVerificationEmailConsumer> logger, IMailService mailService) : IConsumer<UserVerificationEmailEvent>
{
    public async Task Consume(ConsumeContext<UserVerificationEmailEvent> context)
    {
        logger.LogInformation("UserVerificationEmailConsumer received: {Email}", context.Message.Email);
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure", "Templates", "VerificationEmailTemplate.html");
        var templateContent = await File.ReadAllTextAsync(templatePath);
        var message = templateContent.Replace("{{VerificationLink}}", context.Message.VerificationLink);

        await mailService.SendEmailAsync(context.Message.Email, "Email Verification", message);
    }
}