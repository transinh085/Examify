using Microsoft.EntityFrameworkCore;

namespace Examify.Classroom.Data;

public static class Extensions
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {

        builder.AddNpgsqlDbContext<ClassroomContext>("classDb", configureDbContextOptions:
            dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder
                    .UseNpgsql(optionsBuilder =>
                    {
                        optionsBuilder.MigrationsAssembly(typeof(ClassroomContext).Assembly.FullName);
                        optionsBuilder.CommandTimeout(300);
                    });
            });

        builder.Services.AddMigration<ClassroomContext, ClassroomContextSeed>();
        return builder;
    }
}