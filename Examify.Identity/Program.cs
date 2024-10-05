using System.Reflection;
using Examify.Identity.Features.ConnectToken;
using Examify.Identity.Infrastructure.Data;
using Examify.Identity.Infrastructure.Identity;
using Examify.Identity.Infrastructure.Jwt;
using Examify.Identity.Interfaces;
using Examify.Identity.Repositories;
using Examify.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);
builder.AddPersistence();

// Identity
builder.Services.AddIdentityInfrastructure(builder.Configuration);

// OpenIddict
builder.Services.ConfigureAuthServer();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ConnectTokenEndpoint>();

var app = builder.Build();

app.UseInfrastructure(app.Environment);
app.Run();