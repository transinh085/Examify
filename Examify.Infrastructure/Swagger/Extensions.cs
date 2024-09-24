using Examify.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Examify.Infrastructure.Swagger;

public static class Extensions
{
    public static void UseSwaggerExtension(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }

    internal static void AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration)
    {
        var swaggerOptions = services.BindValidateReturn<SwaggerOptions>(configuration);
        _ = services.AddSwaggerGen(config =>
        {
            config.CustomSchemaIds(type => type.ToString());
            config.MapType<DateOnly>(() => new OpenApiSchema()
            {
                Type = "string",
                Format = "date"
            });

            config.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = swaggerOptions.Title,
                    Description = swaggerOptions.Description,
                    Contact = new OpenApiContact
                    {
                        Name = swaggerOptions.Name,
                        Email = swaggerOptions.Email,
                    },
                });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    Array.Empty<string>()
                }
            });

            config.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Input your Bearer token to access this API",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
            });
        });
    }
}