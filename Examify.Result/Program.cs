using System.Reflection;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;
using Examify.Result.Hubs;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.Services.AddSignalR();
builder.AddInfrashtructure(assembly);
builder.Services.AddJwtWithSignalR(builder.Configuration, hubPath: "/result-hub");

var app = builder.Build();
app.MapHub<ResultHub>("result-hub");
app.UseInfrastructure(app.Environment, useAuthentication: true);
app.Run();