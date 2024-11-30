using System.Reflection;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;
using Examify.Result.Grpc;
using Examify.Result.Infrastructure.Data;
using Examify.Result.Infrastructure.Messaging;
using Examify.Result.Repositories;
using Examify.Result.Infrastructure.GrpcClient;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);
builder.AddPersistence();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddGrpc();
builder.Services.AddGrpcServices();

builder.AddMessaging();


// Register repositories
builder.Services.AddScoped<IQuizResultRepository, QuizResultRepository>();
builder.Services.AddScoped<IQuestionResultRepository, QuestionResultRepository>();
builder.Services.AddScoped<IAnswerResultRepository, AnswerResultRepository>();

var app = builder.Build();
app.UseInfrastructure(app.Environment, useAuthentication: true);
app.MapGrpcService<QuizResultService>();
app.Run();