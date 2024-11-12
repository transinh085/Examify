using System.Reflection;
using Examify.Identity.Grpc;
using Examify.Identity.Infrastructure.Data;
using Examify.Identity.Infrastructure.Identity;
using Examify.Identity.Infrastructure.Jwt;
using Examify.Identity.Repositories;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddGrpc();
builder.AddIdentityInfrastructure();
builder.AddPersistence();
builder.AddInfrashtructure(assembly);

builder.Services.AddJwt(builder.Configuration);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

var app = builder.Build();

app.UseInfrastructure(app.Environment, useAuthentication: true);
app.MapGrpcService<IdentityService>();
app.Run();