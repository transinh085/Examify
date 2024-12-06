using MassTransit;

namespace Examify.Quiz.Infrastructure.Message;

public static class Extensions
{
	public static IHostApplicationBuilder AddMessaging(this IHostApplicationBuilder builder)
	{
		builder.Services.AddMassTransit(x =>
		{
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
