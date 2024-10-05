using System.Reflection;
using Examify.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Examify.Identity.Infrastructure.Data;

/// <remarks>
/// Add migrations using the following command inside the 'Examify.Identity' project directory:
///
/// dotnet ef migrations add --context IdentityContext [migration-name] -o Infrastructure/Data/Migrations
/// </remarks>
public class IdentityContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}