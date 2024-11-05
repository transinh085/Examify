using Examify.Notification.Configs;
using Examify.Notification.Services;
using Notification;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddGrpc();
builder.Services.AddGrpcClient<Classroom.ClassroomClient>(
    o => o.Address = new("https://localhost:7118"));

var emailSettings = builder.Configuration.GetSection("EmailSettings").Get<EmailSettings>();
builder.Services.AddSingleton(emailSettings);
builder.Services.AddTransient<EmailService>();


var app  = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();