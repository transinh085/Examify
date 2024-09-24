using Examify.Class.Data;

namespace Examify.Class.Extensions;

public static class Extensions
{
    public static IHostApplicationBuilder AddDatabase(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<AppDbContext>("postgreSql");
        return builder;
    }
}