using Examify.Identity.Entities;
using Examify.Identity.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using OpenIddict.Abstractions;

namespace Examify.Identity.Infrastructure.Identity;

public static class Extensions
{
    public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
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

        services.Configure<IdentityOptions>(options =>
        {
            options.ClaimsIdentity.UserNameClaimType = OpenIddictConstants.Claims.Name;
            options.ClaimsIdentity.UserIdClaimType = OpenIddictConstants.Claims.Subject;
            options.ClaimsIdentity.RoleClaimType = OpenIddictConstants.Claims.Role;
            options.ClaimsIdentity.EmailClaimType = OpenIddictConstants.Claims.Email;
            options.SignIn.RequireConfirmedAccount = false;
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanRead", policy => policy.RequireClaim("CanRead", "true"));
            options.AddPolicy("CanWrite", policy => policy.RequireClaim("CanWrite", "true"));
            options.AddPolicy("CanDelete", policy => policy.RequireClaim("CanDelete", "true"));
        });
        return services;
    }
}