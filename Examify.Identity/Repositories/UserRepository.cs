using Examify.Identity.Entities;
using Examify.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Examify.Identity.Repositories;

public class UserRepository(UserManager<AppUser> userManager) : IUserRepository
{
    public async Task<AppUser> CreateUserAsync(AppUser user, string password)
    {
        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "User");
        }

        return user;
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        return user == null;
    }

    public Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return Task.FromResult(userManager.Users.AsEnumerable());
    }

    public async Task<AppUser> GetByIdAsync(string id)
    {
        return await userManager.FindByIdAsync(id);
    }

    public Task<AppUser> GetByEmailAsync(string email)
    {
        return userManager.FindByEmailAsync(email);
    }

    public async Task<bool> DeleteAsync(AppUser user)
    {
        var result = await userManager.DeleteAsync(user);
        return result.Succeeded;
    }

    public async Task<bool> VerifyLoginAsync(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null) return false;
        return await userManager.CheckPasswordAsync(user, password);
    }
}