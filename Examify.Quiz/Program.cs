using System.Reflection;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;
using Examify.Quiz.Grpc;
using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Infrastructure.GrpcClient;
using Examify.Quiz.Infrastructure.Message;
using Examify.Quiz.Repositories.Questions;
using Examify.Quiz.Repositories.Quiz;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);
builder.AddPersistence();
builder.Services.AddGrpcServices();
builder.Services.AddJwt(builder.Configuration);
builder.AddMessaging();

// Register repositories
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuizMetaService, QuizMetaService>();

var app = builder.Build();

app.UseInfrastructure(app.Environment, useAuthentication: true);

// Register gRPC clients
app.MapGrpcService<QuizGrpcService>();
app.MapGrpcService<QuestionGrpcService>();
app.Run();