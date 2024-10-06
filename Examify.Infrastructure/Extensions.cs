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
        
        builder.Services.AddEndpoints(applicationAssembly);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSerializers();
        builder.Services.AddCustomExceptionHandler();
        // builder.ConfigureSerilog(appOptions.Name);
        
        builder.Services.AddJwt(config);
        
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
    
    public static void UseInfrastructure(this WebApplication app, IWebHostEnvironment env, bool enableSwagger = true)
    {
        //Preserve Order
        app.UseCors(AllowAllOrigins);
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCustomExceptionHandler();
        app.MapEndpoints();
        app.MapDefaultEndpoints();
        if (enableSwagger) app.UseSwaggerExtension(env);
    }
}