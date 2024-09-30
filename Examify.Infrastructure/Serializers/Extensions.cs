using Examify.Core.Serializers;

namespace Examify.Infrastructure.Serializers;

public static class Extensions
{
    public static IServiceCollection AddSerializers(this IServiceCollection services)
    {
        services.AddTransient<ISerializerService, NewtonSoftService>();
        return services;
    } 
}