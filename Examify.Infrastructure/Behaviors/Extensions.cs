using MediatR;

namespace Examify.Infrastructure.Behaviors;

public static class Extensions
{
    public static IServiceCollection AddBehaviours(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PaginationBehavior<,>));
        return services;
    }
}