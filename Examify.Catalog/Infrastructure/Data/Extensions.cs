using Microsoft.EntityFrameworkCore;

namespace Examify.Catalog.Infrastructure.Data;

public static class Extensions
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<CatalogContext>("catalogDb", configureDbContextOptions:
            dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder
                    .UseNpgsql(optionsBuilder =>
                    {
                        optionsBuilder.MigrationsAssembly(typeof(CatalogContext).Assembly.FullName);
                        optionsBuilder.CommandTimeout(300);
                    });
            });

        builder.Services.AddMigration<CatalogContext, CatalogContextSeed>();
        return builder;
    }
}