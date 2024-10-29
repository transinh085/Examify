using Examify.Quiz.Entities;
using Examify.Quiz.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.AddMongoDBClient("mongodb");
builder.Services.AddSingleton<MongoDbContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/tests", async (MongoDbContext dbContext) =>
{
    var test = new Test
    {
        Name = "hgbaodev",
    };
    await dbContext.CreateTestAsync(test);
    var tests = await dbContext.GetAllTestsAsync();
    return Results.Ok(tests);
});

app.Run();