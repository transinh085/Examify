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
            LastName = "Admin",
            Image = "https://avatars.githubusercontent.com/u/120194990?v=4"
        };

        userManager.CreateAsync(user, "12345678").Wait();
        userManager.AddToRoleAsync(user, "Admin").Wait();

        var user2 = new AppUser
        {
            UserName = "user",
            Email = "transinh085@gmail.com",
            FirstName = "Sinh",
            LastName = "Tran",
            Image = "https://avatars.githubusercontent.com/u/45101901?v=4",
            EmailConfirmed = true
        };
        userManager.CreateAsync(user2, "12345678").Wait();
        userManager.AddToRoleAsync(user2, "User").Wait();

        var user3 = new AppUser
        {
            UserName = "hgbaodev",
            Email = "musicanime2501@gmail.com",
            FirstName = "Gia",
            LastName = "Bảo",
            Image = "https://avatars.githubusercontent.com/u/120194990?v=4",
            EmailConfirmed = true
        };
        userManager.CreateAsync(user3, "12345678").Wait();
        userManager.AddToRoleAsync(user3, "User").Wait();

        var user4 = new AppUser
        {
            UserName = "quanphat",
            Email = "quanphat@gmail.com",
            FirstName = "Quan",
            LastName = "Phat",
            Image = "https://avatars.githubusercontent.com/u/93178609?v=4",
            EmailConfirmed = true
        };
        userManager.CreateAsync(user4, "12345678").Wait();
        userManager.AddToRoleAsync(user4, "User").Wait();
        
        var user5 = new AppUser
        {
            UserName = "tungbao",
            Email = "tungbao@gmail.com",
            FirstName = "Tung",
            LastName = "Bao",

            Image = "https://avatars.githubusercontent.com/u/93178609?v=4",
            EmailConfirmed = true
        };
        userManager.CreateAsync(user5, "12345678").Wait();
        userManager.AddToRoleAsync(user5, "User").Wait();

        return Task.CompletedTask;
    }
}