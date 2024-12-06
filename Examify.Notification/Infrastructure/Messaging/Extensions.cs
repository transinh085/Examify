using Examify.Notification.Consumers;
using MassTransit;

namespace Examify.Notification.Infrastructure.Messaging;

public static class Extensions
{
    public static IHostApplicationBuilder AddMessaging(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            x.AddConsumer<UserJoinedExamConsumer>();
            x.AddConsumer<UserPasswordResetConsumer>();
            x.AddConsumer<UserVerificationEmailConsumer>();
            x.AddConsumer<StartExamComsumer>();
            x.AddConsumer<UpdateExamComsumer>();

			x.UsingRabbitMq(
                (context, cfg) =>
                {
                    cfg.Host(builder.Configuration.GetConnectionString("RabbitMQ")!);
                    cfg.ConfigureEndpoints(context);
                });
        });

        builder.Services.AddMassTransitHostedService();
        return builder;
    }
}