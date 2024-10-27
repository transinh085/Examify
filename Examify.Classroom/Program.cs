using System.Reflection;
using Examify.Classroom.Data;
using Examify.Classroom.Grpc;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);
builder.Services.AddGrpc();
builder.AddPersistence();
builder.Services.AddJwt(builder.Configuration);

var app = builder.Build();

app.MapGrpcService<ClassroomService>();
app.UseInfrastructure(app.Environment, useAuthentication: true);
app.Run();