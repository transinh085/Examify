using Examify.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await userManager.Users.ToListAsync();
    }

    public async Task<AppUser?> GetByIdAsync(string id)
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

    public async Task<bool> UpdatePasswordAsync(AppUser user, string oldPassword, string newPassword)
    {
        var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        
        return result.Succeeded;
    }
    
    public async Task<bool> UpdateUserAsync(AppUser user)
    {
        var result = await userManager.UpdateAsync(user);
        
        return result.Succeeded;
    }

    public async Task<bool> UpdateUserImageAsync(AppUser user)
    {
        var result = await userManager.UpdateAsync(user);
        return result.Succeeded;    
    }
}