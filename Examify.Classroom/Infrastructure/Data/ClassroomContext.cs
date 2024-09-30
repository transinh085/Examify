using Microsoft.EntityFrameworkCore;

namespace Examify.Classroom.Data;

/// <remarks>
/// Add migrations using the following command inside the 'Examify.Classroom' project directory:
///
/// dotnet ef migrations add --context ClassroomContext [migration-name] -o Infrastructure/Data/Migrations
/// </remarks>
public class ClassroomContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Domain.Classroom> Classrooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClassroomContext).Assembly);
    }
}