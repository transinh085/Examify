using Examify.Identity.Entities;

namespace Examify.Identity.Repositories;

public interface IUserVerificationRepository
{
    Task<UserVerification> Create(UserVerification userVerification);
    
    Task<UserVerification?> FindByToken(string token);
    
    Task<bool> Delete(UserVerification userVerification);
}