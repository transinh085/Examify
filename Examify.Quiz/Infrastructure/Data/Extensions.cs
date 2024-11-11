using Microsoft.EntityFrameworkCore;
using Quiz;

namespace Examify.Quiz.Infrastructure.Data;

public static class Extensions
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<QuizContext>("quizDb", configureDbContextOptions:
            dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder
                    .UseNpgsql(optionsBuilder =>
                    {
                        optionsBuilder.MigrationsAssembly(typeof(QuizContext).Assembly.FullName);
                        optionsBuilder.CommandTimeout(300);
                    });
            });

        builder.Services.AddMigration<QuizContext, QuizContextSeed>();
        return builder;
    }
    
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
        services.AddGrpcClient<Grade.GradeClient>(options =>
        {
            options.Address = new Uri("https://localhost:7085");
        });
        services.AddGrpcClient<Identity.IdentityClient>(options =>
        {
            options.Address = new Uri("https://localhost:7036");
        });
        return services;
    }
}