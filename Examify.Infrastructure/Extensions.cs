using System.Reflection;
using Examify.Infrastructure.Options;
using FluentValidation;
using Examify.Infrastructure.Behaviors;
using Examify.Infrastructure.Endpoint;
using Examify.Infrastructure.Hosting;
using Examify.Infrastructure.Middlewares;
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
        var appOptions = builder.Services.BindValidateReturn<AppOptions>(config);
    
        // Cors
        builder.Services.AddCors(options => options.AddPolicy(
            name: AllowAllOrigins,
            builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            }));
        
        builder.Services.AddExceptionMiddleware();
        builder.Services.AddEndpoints(applicationAssembly);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSerializers();
        // builder.ConfigureSerilog(appOptions.Name);
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        if (applicationAssembly != null)
        {
            builder.Services.AddAutoMapper(applicationAssembly);
            builder.Services.AddBehaviors();
            builder.Services.AddValidatorsFromAssembly(applicationAssembly, ServiceLifetime.Transient);
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
        }

        if (enableSwagger) builder.Services.AddSwaggerExtension(config);
        builder.AddServiceDefaults();
    }
    
    public static void UseInfrastructure(this WebApplication app, IWebHostEnvironment env, bool enableSwagger = true)
    {
        //Preserve Order
        app.UseCors(AllowAllOrigins);
        app.UseExceptionMiddleware();
        // app.UseAuthentication();
        // app.UseAuthorization();
        app.MapEndpoints();
        app.MapDefaultEndpoints();
        if (enableSwagger) app.UseSwaggerExtension(env);
    }
}