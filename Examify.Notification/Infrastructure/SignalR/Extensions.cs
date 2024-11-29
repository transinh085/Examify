using Examify.Infrastructure.Jwt;
using Examify.Notification.Hubs;
using Microsoft.AspNetCore.Http.Connections;

namespace Examify.Notification.Infrastructure.SignalR;

public static class Extensions
{
    public static IHostApplicationBuilder AddSignalRService(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSignalR();
        builder.Services.AddJwtWithSignalR(builder.Configuration, hubPath: "/result-hub");
        return builder;
    }
    
    public static IApplicationBuilder UseSignalR(this WebApplication app)
    {
        app.MapHub<ResultHub>("result-hub");
        return app;
    }
}