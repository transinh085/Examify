using Examify.Catalog.Entities;

namespace Examify.Catalog.Infrastructure.Data;

public class CatalogContextSeed : IDbSeeder<CatalogContext>
{
    public Task SeedAsync(CatalogContext context)
    {
        var subject = new Subject
        {
            Name = "Mathematics"
        };
        context.Subjects.Add(subject);
        context.SaveChanges();
        return Task.CompletedTask;
    }
}