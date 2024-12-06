using Examify.Identity.Entities;
using Examify.Identity.Infrastructure.Data;
using Examify.Infrastructure.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Examify.Identity.Infrastructure.Identity;

public static class Extensions
{
    public static IHostApplicationBuilder AddIdentityInfrastructure(this IHostApplicationBuilder builder)
    {
        var jwtOptions = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
        var fbOptions = builder.Configuration.GetSection(nameof(FacebookOptions)).Get<FacebookOptions>();
        var googleOptions = builder.Configuration.GetSection(nameof(GoogleOptions)).Get<GoogleOptions>();
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

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                    ClockSkew = System.TimeSpan.Zero
                };
            })
            .AddFacebook(options =>
            {
                options.AppId = fbOptions.AppId;
                options.AppSecret = fbOptions.AppSecret;
            })
            .AddGoogle(options =>
            {
                options.ClientId = googleOptions.ClientId;
                options.ClientSecret = googleOptions.ClientSecret;
            });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("User", policy => policy.RequireRole("User"));
        });

        return builder;
    }
}