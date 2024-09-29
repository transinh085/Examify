using System.Reflection;
using Examify.Classroom.Data;
using Examify.Classroom.Grpc;
using Examify.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddPersistence();
builder.Services.AddGrpc();
builder.AddInfrashtructure(assembly);
var app = builder.Build();

app.MapGrpcService<ClassroomService>();
app.UseInfrastructure(app.Environment);
app.Run();