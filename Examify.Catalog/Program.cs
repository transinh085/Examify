using System.Reflection;
using Examify.Catalog.Grpc;
using Examify.Catalog.Infrastructure.Data;
using Examify.Catalog.Repositories.Grades;
using Examify.Catalog.Repositories.Language;
using Examify.Catalog.Repositories.Subjects;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;

var builder = WebApplication.CreateBuilder(args);

var assembly = Assembly.GetExecutingAssembly();
builder.AddInfrashtructure(assembly);
builder.Services.AddGrpc();
builder.AddPersistence();
builder.Services.AddJwt(builder.Configuration);

builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

var app = builder.Build();

app.MapGrpcService<LanguageService>();
app.MapGrpcService<SubjectService>();
app.UseInfrastructure(app.Environment, useAuthentication: true);

app.Run();