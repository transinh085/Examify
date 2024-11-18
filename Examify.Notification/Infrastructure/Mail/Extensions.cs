using Examify.Notification.Mail;

namespace Examify.Notification.Infrastructure.Mail;

public static class Extensions
{
    public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailOptions>(configuration.GetSection(nameof(MailOptions)));
        services.AddTransient<IMailService, MailService>();
        return services;
    }
}