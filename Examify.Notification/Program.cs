using System.Reflection;
using Examify.Infrastructure;
using Examify.Notification.Infrastructure.Mail;
using Examify.Notification.Infrastructure.Messaging;
using Examify.Result.Infrastructure.SignalR;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly, enableSwagger: false);
builder.AddSignalRService();
builder.AddMessaging();
builder.Services.AddEmailService(builder.Configuration);

var app = builder.Build();
app.UseInfrastructure(app.Environment, useAuthentication: true, enableSwagger: false);
app.UseSignalR();
app.Run();