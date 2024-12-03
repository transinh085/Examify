using System.Reflection;
using Examify.Infrastructure;
using Examify.Notification.Grpc.Clients;
using Examify.Notification.Infrastructure.GrpcClient;
using Examify.Notification.Infrastructure.Mail;
using Examify.Notification.Infrastructure.Messaging;
using Examify.Notification.Infrastructure.SignalR;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly, enableSwagger: false);
builder.AddSignalRService();
builder.AddMessaging();
builder.Services.AddEmailService(builder.Configuration);
builder.Services.AddGrpcServices();

builder.Services.AddScoped<INotificationMetaService, NotificationMetaService>();

var app = builder.Build();
app.UseInfrastructure(app.Environment, useAuthentication: true, enableSwagger: false);
app.UseSignalR();
app.Run();