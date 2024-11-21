using Microsoft.EntityFrameworkCore;

namespace Examify.Result.Infrastructure.Data;

public static class Extensions
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<QuizResultContext>("resultDb", configureDbContextOptions:
            dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder
                    .UseNpgsql(optionsBuilder =>
                    {
                        optionsBuilder.MigrationsAssembly(typeof(QuizResultContext).Assembly.FullName);
                        optionsBuilder.CommandTimeout(300);
                    });
            });

        builder.Services.AddMigration<QuizResultContext, QuizResultSeeder>();
        return builder;
    }
}