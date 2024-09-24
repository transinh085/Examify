using Microsoft.EntityFrameworkCore;

namespace Examify.Class.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}