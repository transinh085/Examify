using Result;

namespace Examify.Result.Infrastructure.GrpcClient;

public static class Extensions
{
    public static IServiceCollection AddGrpcServices(this IServiceCollection services)
    {
        services.AddGrpcClient<QuizGrpcService.QuizGrpcServiceClient>(options =>
        {
            options.Address = new Uri("https://localhost:7299");
        });
        services.AddGrpcClient<QuestionGrpcService.QuestionGrpcServiceClient>(options =>
        {
            options.Address = new Uri("https://localhost:7299");
        });
        services.AddGrpcClient<Identity.IdentityClient>(options =>
        {
            options.Address = new Uri("https://localhost:7036");
        });
        
        return services;
    }
}