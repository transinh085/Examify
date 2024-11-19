

namespace Examify.Result.Infrastructure.GrpcClient;

public static class Extensions
{
    public static IServiceCollection AddGrpcServices(this IServiceCollection services)
    {
        services.AddGrpcClient<global::Result.Quiz.QuizClient>(options =>
        {
            options.Address = new Uri("https://localhost:7299");
        });
        return services;
    }
}