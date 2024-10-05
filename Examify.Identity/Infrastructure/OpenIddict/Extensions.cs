using Examify.Identity.Infrastructure.Data;
using Examify.Infrastructure.Options;
using OpenIddict.Abstractions;
using OpenIddict.Validation.AspNetCore;

namespace Examify.Identity.Infrastructure.Jwt;

public static class Extensions
{
    public static IServiceCollection AddAuthValidation(this IServiceCollection services, IConfiguration config)
    {
        var jwtSettings = services.BindValidateReturn<JwtSettings>(config);

        services.AddOpenIddict()
            .AddValidation(options =>
            {
                options.SetIssuer(jwtSettings.Issuer);
                options.AddAudiences(jwtSettings.Audience);
                options.UseSystemNetHttp();
            });

        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        services.AddAuthorization();

        return services;
    }

    public static IServiceCollection ConfigureAuthServer(this IServiceCollection services)
    {
        services.AddOpenIddict()
            .AddCore(options => options.UseEntityFrameworkCore().UseDbContext<IdentityContext>())
            .AddServer(options =>
            {
                // Enable the token endpoint.
                options.SetTokenEndpointUris("/connect/token");

                // Enable the password flow.
                options.AllowPasswordFlow()
                    .AllowRefreshTokenFlow();
                
                // Accept anonymous clients (i.e clients that don't send a client_id).
                // options.AcceptAnonymousClients();

                // Register the signing and encryption credentials.
                options.AddDevelopmentEncryptionCertificate()
                    .AddDevelopmentSigningCertificate()
                    .DisableAccessTokenEncryption();

                // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                options.UseAspNetCore()
                    .EnableTokenEndpointPassthrough();
            }).AddValidation(options =>
            {
                options.UseLocalServer();
                options.UseAspNetCore();
            });

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        });
        services.AddAuthorization();

        services.AddHostedService<SeedClientsAndScopes>();

        return services;
    }
}