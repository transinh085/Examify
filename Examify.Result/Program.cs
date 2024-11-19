using System.Reflection;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;
using Examify.Result.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);
builder.Services.AddJwt(builder.Configuration);
builder.AddMessaging();

var app = builder.Build();
app.UseInfrastructure(app.Environment, useAuthentication: true);
app.Run();