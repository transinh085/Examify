using System.Reflection;
using Examify.Infrastructure.Options;
using FluentValidation;
using Examify.Infrastructure.Behaviors;
using Examify.Infrastructure.Endpoint;
using Examify.Infrastructure.Exceptions;
using Examify.Infrastructure.Hosting;
using Examify.Infrastructure.Jwt;
using Examify.Infrastructure.Serializers;
using Examify.Infrastructure.Swagger;

namespace Examify.Infrastructure;

public static class Extensions
{
    private static readonly string AllowAllOrigins = "CorsPolicy";

    public static void AddInfrashtructure(this WebApplicationBuilder builder, Assembly? applicationAssembly = null,
        bool enableSwagger = true)
    {
        var config = builder.Configuration;

        // Cors
        builder.Services.AddCors(options => options.AddPolicy(
            name: AllowAllOrigins,
            builder =>
            {
                builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            }));

        builder.Services.AddEndpoints(applicationAssembly);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSerializers();
        builder.Services.AddCustomExceptionHandler();

        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        if (applicationAssembly != null)
        {
            builder.Services.AddAutoMapper(applicationAssembly);
            builder.Services.AddBehaviours();
            builder.Services.AddValidatorsFromAssembly(applicationAssembly);
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
        }

        if (enableSwagger) builder.Services.AddSwaggerExtension(config);
        builder.AddServiceDefaults();
    }

    public static void UseInfrastructure(this WebApplication app, IWebHostEnvironment env, bool enableSwagger = true,
        bool useAuthentication = false)
    {
        //Preserve Order
        app.UseCustomExceptionHandler();
        app.UseCors(AllowAllOrigins);

        if (useAuthentication)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        app.MapEndpoints();
        app.MapDefaultEndpoints();
        if (enableSwagger) app.UseSwaggerExtension(env);
    }
}