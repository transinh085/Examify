using Microsoft.EntityFrameworkCore;

namespace Examify.Classroom.Data;

public class ClassroomContext : DbContext
{
    public ClassroomContext(DbContextOptions<ClassroomContext> options) : base(options)
    {
        
    }
    
    public DbSet<Domain.Classroom> Classrooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}