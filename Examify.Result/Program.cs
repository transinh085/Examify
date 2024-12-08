using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;
using Examify.Result.Grpc;
using Examify.Result.Grpc.Client;
using Examify.Result.Infrastructure.Data;
using Examify.Result.Infrastructure.GrpcClient;
using Examify.Result.Infrastructure.Messaging;
using Examify.Result.Repositories.AnswerResults;
using Examify.Result.Repositories.JoinQuizzes;
using Examify.Result.Repositories.QuestionResults;
using Examify.Result.Repositories.QuizResults;
using System.Reflection;

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
builder.Services.AddScoped<IJoinQuizRepository, JoinQuizRepository>();
builder.Services.AddScoped<IResultQuizMetaService, ResultQuizMetaService>();

var app = builder.Build();
app.UseInfrastructure(app.Environment, useAuthentication: true);
app.MapGrpcService<QuizResultService>();
app.Run();