using Examify.Infrastructure.Jwt;
using Examify.Notification.Hubs;

namespace Examify.Notification.Infrastructure.SignalR;

public static class Extensions
{
    public static IHostApplicationBuilder AddSignalRService(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSignalR();
        builder.Services.AddJwtWithSignalR(builder.Configuration, hubPath: "/notification-hub");
        return builder;
    }
    
    public static IApplicationBuilder UseSignalR(this WebApplication app)
    {
        app.MapHub<NotificationHub>("notification-hub");
        return app;
    }
}