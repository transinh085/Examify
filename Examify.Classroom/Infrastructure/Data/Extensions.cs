using Microsoft.EntityFrameworkCore;

namespace Examify.Classroom.Data;

public static class Extensions
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMigration<ClassroomContext, ClassroomContextSeed>();

        builder.AddNpgsqlDbContext<ClassroomContext>("classDb", configureDbContextOptions:
            dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder
                    .UseNpgsql(optionsBuilder =>
                    {
                        optionsBuilder.MigrationsAssembly(typeof(ClassroomContext).Assembly.FullName);
                        optionsBuilder.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                    });
            });

        builder.Services.AddMigration<ClassroomContext, ClassroomContextSeed>();

        return builder;
    }
}