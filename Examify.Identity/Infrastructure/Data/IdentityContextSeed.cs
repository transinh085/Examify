namespace Examify.Identity.Infrastructure.Data;

public class IdentityContextSeed : IDbSeeder<IdentityContext>
{
    public Task SeedAsync(IdentityContext context)
    {
        return Task.CompletedTask;
    }
}