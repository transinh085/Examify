using System.Reflection;
using Examify.Class.Extensions;
using Examify.Class.Grpc;
using Examify.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddDatabase();
builder.Services.AddGrpc();
builder.AddInfrashtructure(assembly);
var app = builder.Build();

app.MapGrpcService<ClassroomService>();
app.UseInfrastructure(app.Environment);
app.Run();