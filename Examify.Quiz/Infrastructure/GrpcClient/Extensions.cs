using Quiz;
using Result;

namespace Examify.Quiz.Infrastructure.GrpcClient;

public static class Extensions
{
    public static IServiceCollection AddGrpcServices(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddGrpcClient<Language.LanguageClient>(options =>
        {
            options.Address = new Uri("https://localhost:7085");
        });
        services.AddGrpcClient<Subject.SubjectClient>(options =>
        {
            options.Address = new Uri("https://localhost:7085");
        });
        services.AddGrpcClient<Grade.GradeClient>(options => { options.Address = new Uri("https://localhost:7085"); });
        services.AddGrpcClient<Identity.IdentityClient>(options =>
        {
            options.Address = new Uri("https://localhost:7036");
        });

        services.AddGrpcClient<QuizResult.QuizResultClient>(options =>
        {
            options.Address = new Uri("https://localhost:7295");
        });

        return services;
    }
}