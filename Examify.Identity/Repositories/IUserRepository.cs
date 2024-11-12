using Examify.Identity.Entities;
using Examify.Identity.Features.GetUsers;

namespace Examify.Identity.Interfaces;

public interface IUserRepository
{
    Task<AppUser> CreateUserAsync(AppUser user, string password);
    Task<bool> IsEmailUniqueAsync(string email);
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser> GetByIdAsync(string id);
    Task<AppUser> GetByEmailAsync(string email);
    Task<bool> DeleteAsync(AppUser user);
    Task<bool> VerifyLoginAsync(string email, string password);
    Task<AppUser> UpdatePasswordAsync(AppUser user,string oldPassword, string newPassword);
}