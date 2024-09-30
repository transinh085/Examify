using System.Reflection;
using Examify.Classroom.Data;
using Examify.Classroom.Features.CreateClassroom;
using Examify.Classroom.Grpc;
using Examify.Infrastructure;
using Examify.Infrastructure.Behaviors;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);

builder.Services.AddGrpc();
builder.AddPersistence();

var app = builder.Build();

app.MapGrpcService<ClassroomService>();
app.UseInfrastructure(app.Environment);
app.Run();