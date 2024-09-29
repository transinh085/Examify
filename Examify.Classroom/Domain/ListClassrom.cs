namespace Examify.Classroom.Domain;

public static class ListClassrom
{
    public static List<Classroom> classrooms = new List<Classroom>
    {
        new Classroom { Id = 1, Name = "Physics Lab", Description = "A lab for physics experiments" },
        new Classroom { Id = 2, Name = "Computer Science Room", Description = "Room equipped with computers" },
        new Classroom { Id = 3, Name = "Math Room", Description = "Room for math classes" },
        new Classroom { Id = 4, Name = "Chemistry Lab", Description = "Lab for chemistry experiments" },
        new Classroom { Id = 4, Name = "Art Studio", Description = "Room for art and design work" }
    };
}