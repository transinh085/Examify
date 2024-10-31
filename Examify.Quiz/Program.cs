using System.Reflection;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;
using Examify.Quiz.Infrastructure.Cloudinary;
using Examify.Quiz.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);
builder.AddPersistence();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddCloudinary(builder.Configuration);

var app = builder.Build();

app.UseInfrastructure(app.Environment, useAuthentication: true);
app.Run();