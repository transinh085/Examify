using Examify.Catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examify.Catalog.Infrastructure.Data;

/// <remarks>
/// Add migrations using the following command inside the 'Examify.Classroom' project directory:
///
/// dotnet ef migrations add --context ClassroomContext [migration-name] -o Infrastructure/Data/Migrations
/// </remarks>
public class CatalogContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Language> Languages { get; set; }
    
    public DbSet<Grade> Grades { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }
}