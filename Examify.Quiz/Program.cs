using System.Reflection;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;
using Examify.Quiz.Grpc;
using Examify.Quiz.Infrastructure.Cloudinary;
using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Questions;
using Examify.Quiz.Repositories.Quiz;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();

builder.AddInfrashtructure(assembly);
builder.AddPersistence();
builder.Services.AddGrpcServices();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddCloudinary(builder.Configuration);

// Register repositories
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

var app = builder.Build();

app.UseInfrastructure(app.Environment, useAuthentication: true);

// Register gRPC clients
app.MapGrpcService<QuizService>();
app.Run();