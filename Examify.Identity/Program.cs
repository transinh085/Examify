using System.Reflection;
using Examify.Identity.Entities;
using Examify.Identity.Infrastructure.Data;
using Examify.Identity.Infrastructure.Jwt;
using Examify.Identity.Interfaces;
using Examify.Identity.Repositories;
using Examify.Infrastructure;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);
builder.AddPersistence();

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

builder.Services.AddJwt(builder.Configuration);
builder.Services.AddAuthorization(options =>
    options.AddPolicy("Something",
        policy => policy.RequireClaim("Permission", "CanViewPage", "CanViewAnything")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

var app = builder.Build();

app.UseInfrastructure(app.Environment);
app.Run();