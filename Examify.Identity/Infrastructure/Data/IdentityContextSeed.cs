using Examify.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Examify.Identity.Infrastructure.Data;

public class IdentityContextSeed(UserManager<AppUser> userManager) : IDbSeeder<IdentityContext>
{
    public Task SeedAsync(IdentityContext context)
    {
        var user = new AppUser
        {
            UserName = "admin",
            Email = "admin@gmail.com",
            FirstName = "Admin",
            LastName = "Admin"
        };

        userManager.CreateAsync(user, "12345678").Wait();
        userManager.AddToRoleAsync(user, "Admin").Wait();

        var user2 = new AppUser
        {
            UserName = "user",
            Email = "transinh085@gmail.com",
            FirstName = "Sinh",
            LastName = "Tran"
        };
        userManager.CreateAsync(user2, "12345678").Wait();
        userManager.AddToRoleAsync(user2, "User").Wait();

        return Task.CompletedTask;
    }
}