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
        
        var grades = new List<Grade>();
        
        for(int i = 1; i <= 12; i++)
        {
            grades.Add(new Grade
            {
                Name = $"L{i}"
            });
        }
        grades.Add(new Grade { Name = "Đại học" });

        context.Languages.AddRange(languages);
        context.Subjects.AddRange(subjects);
        context.Grades.AddRange(grades);
        context.SaveChanges();

        return Task.CompletedTask;
    }
}