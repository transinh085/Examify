namespace Examify.Classroom.Data;

public class ClassroomContextSeed : IDbSeeder<ClassroomContext>
{
    public async Task SeedAsync(ClassroomContext context)
    {
        if (context.Classrooms.Any())
        {
            var classrooms = new List<Entities.Classroom>
            {
                new Entities.Classroom
                {
                    Id = 1,
                    Name = "Classroom 1",
                    Description = "Classroom 1 Description",
                },
                new Entities.Classroom
                {
                    Id = 2,
                    Name = "Classroom 2",
                    Description = "Classroom 2 Description",
                },
                new Entities.Classroom
                {
                    Id = 3,
                    Name = "Classroom 3",
                    Description = "Classroom 3 Description",
                },
                new Entities.Classroom
                {
                    Id = 4,
                    Name = "Classroom 4",
                    Description = "Classroom 4 Description",
                },
                new Entities.Classroom
                {
                    Id = 5,
                    Name = "Classroom 5",
                    Description = "Classroom 5 Description",
                },
                new Entities.Classroom
                {
                    Id = 6,
                    Name = "Classroom 6",
                    Description = "Classroom 6 Description",
                },
                new Entities.Classroom
                {
                    Id = 7,
                    Name = "Classroom 7",
                    Description = "Classroom 7 Description",
                },
                new Entities.Classroom
                {
                    Id = 8,
                    Name = "Classroom 8",
                    Description = "Classroom 8 Description",
                },
                new Entities.Classroom
                {
                    Id = 9,
                    Name = "Classroom 9",
                    Description = "Classroom 9 Description",
                },
                new Entities.Classroom
                {
                    Id = 10,
                    Name = "Classroom 10",
                    Description = "Classroom 10 Description",
                }
            };
            context.Classrooms.AddRange(classrooms);
            context.SaveChangesAsync();
        }
    }
}