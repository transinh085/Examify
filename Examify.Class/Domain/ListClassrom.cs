namespace Examify.Class.Domain;

public static class ListClassrom
{
    public static List<Classroom> classrooms = new List<Classroom>
    {
        new Classroom { Id = "C001", Name = "Physics Lab", Description = "A lab for physics experiments" },
        new Classroom { Id = "C002", Name = "Computer Science Room", Description = "Room equipped with computers" },
        new Classroom { Id = "C003", Name = "Math Room", Description = "Room for math classes" },
        new Classroom { Id = "C004", Name = "Chemistry Lab", Description = "Lab for chemistry experiments" },
        new Classroom { Id = "C005", Name = "Art Studio", Description = "Room for art and design work" }
    };
}