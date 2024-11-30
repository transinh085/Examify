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
}