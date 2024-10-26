using Examify.Catalog.Entities;

namespace Examify.Catalog.Infrastructure.Data;

public class CatalogContextSeed : IDbSeeder<CatalogContext>
{
    public Task SeedAsync(CatalogContext context)
    {
        var subjects = new List<Subject>();

        for (int i = 1; i <= 30; i++)
        {
            subjects.Add(new Subject
            {
                Name = $"Subject {i}"
            });
        }

        var languages = new List<Language>();
        
        for(int i = 1; i <= 10; i++)
        {
            languages.Add(new Language
            {
                Name = $"Language {i}"
            });
        }
        
        context.Languages.AddRange(languages);
        context.Subjects.AddRange(subjects);
        context.SaveChanges();

        return Task.CompletedTask;
    }
}