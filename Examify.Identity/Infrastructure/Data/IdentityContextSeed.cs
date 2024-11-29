using Examify.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Examify.Identity.Infrastructure.Data;

public class IdentityContextSeed(UserManager<AppUser> userManager) : IDbSeeder<IdentityContext>
{
    public Task SeedAsync(IdentityContext context)
    {
        if (userManager.Users.Any()) return Task.CompletedTask;
        var user = new AppUser
        {
            Id = "7554dbfd-d5a7-4bc2-a85f-9463362a9043",
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
            Id = "ea616dc0-e621-474e-a247-b823b9fe6004",
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
            Id = "0193672e-8194-7e38-9e4f-0e66b722ef4f",
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
            Id = "01936732-e4e3-76bb-a27a-cd2c7bb9171d",
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
            Id = "01936733-3207-7014-9194-b0588a1c3dc5",
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