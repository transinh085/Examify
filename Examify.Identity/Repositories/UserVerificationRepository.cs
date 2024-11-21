using Examify.Identity.Entities;
using Examify.Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examify.Identity.Repositories;

public class UserVerificationRepository(IdentityContext identityContext) : IUserVerificationRepository
{
    public async Task<UserVerification> Create(UserVerification userVerification)
    {
        identityContext.UserVerifications.Add(userVerification);
        await identityContext.SaveChangesAsync();
        return userVerification;
    }

    public async Task<UserVerification?> FindByToken(string token)
    {
        return await identityContext.UserVerifications.FirstOrDefaultAsync(item => item.Token == token);
    }
    
    public async Task<bool> Delete(UserVerification userVerification)
    {
        identityContext.UserVerifications.Remove(userVerification);
        await identityContext.SaveChangesAsync();
        return true;
    }
}