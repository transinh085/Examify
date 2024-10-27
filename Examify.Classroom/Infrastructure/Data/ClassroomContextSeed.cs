namespace Examify.Classroom.Data;

public class ClassroomContextSeed : IDbSeeder<ClassroomContext>
{
    public async Task SeedAsync(ClassroomContext context)
    {
        var classrooms = new List<Entities.Classroom>
        {
            new Entities.Classroom
            {
                Name = "Classroom 1",
                Description = "Classroom 1 Description",
            },
            new Entities.Classroom
            {
                Name = "Classroom 2",
                Description = "Classroom 2 Description",
            },
            new Entities.Classroom
            {
                Name = "Classroom 3",
                Description = "Classroom 3 Description",
            },
            new Entities.Classroom
            {
                Name = "Classroom 4",
                Description = "Classroom 4 Description",
            },
            new Entities.Classroom
            {
                Name = "Classroom 5",
                Description = "Classroom 5 Description",
            },
            new Entities.Classroom
            {
                Name = "Classroom 6",
                Description = "Classroom 6 Description",
            },
            new Entities.Classroom
            {
                Name = "Classroom 7",
                Description = "Classroom 7 Description",
            },
            new Entities.Classroom
            {
                Name = "Classroom 8",
                Description = "Classroom 8 Description",
            },
            new Entities.Classroom
            {
                Name = "Classroom 9",
                Description = "Classroom 9 Description",
            },
            new Entities.Classroom
            {
                Name = "Classroom 10",
                Description = "Classroom 10 Description",
            }
        };
        await context.Classrooms.AddRangeAsync(classrooms);
        await context.SaveChangesAsync();
    }
}