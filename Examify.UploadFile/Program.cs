using System.Reflection;
using Examify.Infrastructure;
using Examify.UploadFile.Infrastructure.Cloudinary;

var builder = WebApplication.CreateBuilder(args);

var assembly = Assembly.GetExecutingAssembly();
builder.AddInfrashtructure(assembly);
builder.Services.AddCloudinary(builder.Configuration);

var app = builder.Build();

app.UseInfrastructure(app.Environment, useAuthentication: false);
app.Run();