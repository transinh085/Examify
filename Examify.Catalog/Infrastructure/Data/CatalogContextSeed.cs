using Examify.Catalog.Entities;

namespace Examify.Catalog.Infrastructure.Data;

public class CatalogContextSeed : IDbSeeder<CatalogContext>
{
    public Task SeedAsync(CatalogContext context)
    {
        if (!context.Subjects.Any())
        {
            var subjects = new List<Subject>
            {
                new Subject { Id = Guid.Parse("59820f61-ada9-44e8-9a45-790981fe05f0"), Name = "Math" },
                new Subject { Id = Guid.Parse("462175fb-55b4-40e0-b317-8f4d58ca9615"), Name = "Physics" },
                new Subject { Id = Guid.Parse("048d1a67-4ced-4189-85e6-c2803577f040"), Name = "Chemistry" },
                new Subject { Id = Guid.Parse("2f921f98-5b80-4916-943c-31c6a88ca70e"), Name = "Programming" },
                new Subject { Id = Guid.Parse("f9c0f102-9fab-4f11-a76c-33efd4439af0"), Name = "English" },
                new Subject { Id = Guid.Parse("d34d0164-6d96-4e58-b732-abbc35ce4d28"), Name = "History" },
                new Subject { Id = Guid.Parse("deb9e2f7-6c42-43bd-a675-bf5f59b9f821"), Name = "Geography" }
            };
            context.Subjects.AddRange(subjects);
        }

        if (!context.Languages.Any())
        {
            var languages = new List<Language>
            {
                new Language { Id = Guid.Parse("d9789c96-e0c8-4826-81b3-0eccd22d3508"), Name = "English" },
                new Language { Id = Guid.Parse("92458564-28b3-449c-b2c5-645740600368"), Name = "French" },
                new Language { Id = Guid.Parse("d46ba410-2cef-4d7a-b047-dedf9ea141c6"), Name = "Spanish" },
                new Language { Id = Guid.Parse("55ad2a7e-a946-428a-8b04-235c1e56f8fd"), Name = "German" },
                new Language { Id = Guid.Parse("d069ad6f-3a09-4f88-be39-e8686f93e3fc"), Name = "Japanese" },
                new Language { Id = Guid.Parse("8316717e-3fe3-40b2-84dc-f573c019b9db"), Name = "Chinese" },
                new Language { Id = Guid.Parse("bb180af3-9e24-4889-8c04-c2597962b2c8"), Name = "Italian" },
                new Language { Id = Guid.Parse("0494440d-fe37-43d3-9fe2-cb237c18a500"), Name = "Portuguese" },
                new Language { Id = Guid.Parse("505e2b60-be2e-4734-b4a7-fbd82b1f45f0"), Name = "Russian" },
                new Language { Id = Guid.Parse("8925686e-1fa7-4c6f-9e9a-90a360acf9b9"), Name = "Korean" }
            };
            context.Languages.AddRange(languages);
        }

        if (!context.Grades.Any())
        {
            var grades = new List<Grade>
            {
                new Grade { Id = Guid.Parse("c9636b6d-8a38-423e-bddd-e7d0522db4b3"), Name = "Grade 1" },
                new Grade { Id = Guid.Parse("bac8156d-9e33-4054-8a56-8d8ca6647cfb"), Name = "Grade 2" },
                new Grade { Id = Guid.Parse("fe1ab3da-f5d9-4b63-ba57-3dbc14a9a82b"), Name = "Grade 3" },
                new Grade { Id = Guid.Parse("eaae3de7-126e-4a1c-b301-236049605952"), Name = "Grade 4" },
                new Grade { Id = Guid.Parse("56873e58-0c4f-4f33-a7c6-faf1bb3e6b40"), Name = "Grade 5" },
                new Grade { Id = Guid.Parse("3f619aa6-6987-4108-aab3-7624895322ca"), Name = "Grade 6" },
                new Grade { Id = Guid.Parse("e082c766-4bbc-41ae-abbc-e4fc76a4aff9"), Name = "Grade 7" },
                new Grade { Id = Guid.Parse("f2fe3f16-41f4-43da-b253-14873bb07100"), Name = "Grade 8" },
                new Grade { Id = Guid.Parse("953829bd-5e12-4799-8bd3-3d78d0507097"), Name = "Grade 9" },
                new Grade { Id = Guid.Parse("6afce851-669f-4ee8-a082-814f3633d2a3"), Name = "Grade 10" },
                new Grade { Id = Guid.Parse("14f279e1-0fe5-478b-aeea-e2ef105cc51b"), Name = "Grade 11" },
                new Grade { Id = Guid.Parse("e2cee932-4bce-40e5-b3be-16829008bb02"), Name = "Grade 12" },
                new Grade { Id = Guid.Parse("ccc9fa86-9ba3-438a-8930-8db470ed6d15"), Name = "College" },
                new Grade { Id = Guid.Parse("45304ba8-da09-46b9-8400-d5b7a7bb718e"), Name = "University" },
                new Grade { Id = Guid.Parse("b571a3ae-ac82-41cf-bb98-eaddfc012742"), Name = "Master's Program" },
                new Grade { Id = Guid.Parse("4f22f2c9-113d-4ea8-b9da-4bf7d28fbcdc"), Name = "PhD Program" }
            };
            context.Grades.AddRange(grades);
        }

        context.SaveChanges();
        return Task.CompletedTask;
    }
}