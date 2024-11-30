
using Notification;

namespace Examify.Notification.Infrastructure.GrpcClient;

public static class Extensions
{
    public static IServiceCollection AddGrpcServices(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddGrpcClient<Identity.IdentityClient>(options =>
        {
            options.Address = new Uri("https://localhost:7036");
        });
        return services;
    }
}