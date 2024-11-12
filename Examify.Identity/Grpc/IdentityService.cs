using Examify.Identity.Repositories;
using Grpc.Core;
using Identity;

namespace Examify.Identity.Grpc;

public class IdentityService(IUserRepository userRepository) : global::Identity.Identity.IdentityBase
{
    public override async Task<IdentityReply> GetIdentity(IdentityRequest request, ServerCallContext context)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        
        return await Task.FromResult(new IdentityReply
        {
            Id = user?.Id ?? string.Empty,
            Name = user?.FullName ?? string.Empty,
            Image = user?.Image ?? string.Empty
        });
    }
    
}