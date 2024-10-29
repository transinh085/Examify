using MongoDB.Driver;
using Examify.Quiz.Entities;

namespace Examify.Quiz.Infrastructure.Data;

public class MongoDbContext 
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
    }

    public IMongoCollection<Test> Tests => _database.GetCollection<Test>("Tests");

    public async Task<Test> CreateTestAsync(Test test)
    {
        await Tests.InsertOneAsync(test);
        return test;
    }
    public async Task<List<Test>> GetAllTestsAsync()
    {
        return await Tests.Find(_ => true).ToListAsync();
    }
}