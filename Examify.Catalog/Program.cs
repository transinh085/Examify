using System.Reflection;
using Examify.Catalog.Infrastructure.Data;
using Examify.Catalog.Repositories.Language;
using Examify.Infrastructure;
using Examify.Infrastructure.Jwt;

var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly();
builder.AddInfrashtructure(assembly);
builder.AddPersistence();

builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();

var app = builder.Build();

app.UseInfrastructure(app.Environment);

app.Run();