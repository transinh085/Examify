using Examify.Identity.Entities;
using Examify.Identity.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Examify.Identity.Infrastructure.Identity;

public static class Extensions
{
    public static IHostApplicationBuilder AddIdentityInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();
        return builder;
    }
}