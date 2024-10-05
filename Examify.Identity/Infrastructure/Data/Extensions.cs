using Microsoft.EntityFrameworkCore;

namespace Examify.Identity.Infrastructure.Data;

public static class Extensions
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {

        builder.AddNpgsqlDbContext<IdentityContext>("identityDb", configureDbContextOptions:
            dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder
                    .UseNpgsql(optionsBuilder =>
                    {
                        optionsBuilder.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName);
                        optionsBuilder.CommandTimeout(300);
                    });
            });

        builder.Services.AddMigration<IdentityContext, IdentityContextSeed>();
        return builder;
    }
}