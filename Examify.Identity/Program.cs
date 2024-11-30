using System.Reflection;
using Examify.Identity.Grpc;
using Examify.Identity.Infrastructure.Data;
using Examify.Identity.Infrastructure.Identity;
using Examify.Identity.Infrastructure.Jwt;
using Examify.Identity.Repositories;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;
using Examify.Result.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.Configure<FacebookOptions>(builder.Configuration.GetSection(nameof(FacebookOptions)));
builder.Services.Configure<GoogleOptions>(builder.Configuration.GetSection(nameof(GoogleOptions)));


builder.Services.AddGrpc();
builder.AddIdentityInfrastructure();
builder.AddPersistence();
builder.AddInfrashtructure(assembly);
builder.AddMessaging();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserVerificationRepository, UserVerificationRepository>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

var app = builder.Build();

app.UseInfrastructure(app.Environment, useAuthentication: true);
app.MapGrpcService<IdentityService>();
app.Run();