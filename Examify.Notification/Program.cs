using System.Reflection;
using Examify.Infrastructure;
using Examify.Notification.Infrastructure.Mail;
using Examify.Notification.Infrastructure.Messaging;
using Examify.Notification.Infrastructure.SignalR;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);
builder.AddSignalRService();
builder.AddMessaging();
builder.Services.AddEmailService(builder.Configuration);

var app = builder.Build();
app.UseInfrastructure(app.Environment, useAuthentication: true);
app.UseSignalR();
app.Run();