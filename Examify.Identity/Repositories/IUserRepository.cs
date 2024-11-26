using Examify.Identity.Entities;

namespace Examify.Identity.Repositories;

public interface IUserRepository
{
    Task<AppUser> CreateUserAsync(AppUser user, string password);
    Task<bool> IsEmailUniqueAsync(string email);
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetByIdAsync(string id);
    Task<AppUser> GetByEmailAsync(string email);
    Task<bool> DeleteAsync(AppUser user);
    Task<bool> VerifyLoginAsync(string email, string password);

    Task<bool> UpdatePasswordAsync(AppUser user,string oldPassword, string newPassword);
    Task<bool> UpdateUserAsync(AppUser user);
    Task<bool> UpdateUserImageAsync(AppUser user);


}