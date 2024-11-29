using Examify.Identity.Repositories;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Identity;

namespace Examify.Identity.Grpc;

public class IdentityService(IUserRepository userRepository) : global::Identity.Identity.IdentityBase
{
    public override async Task<GetIdentityResponse> GetIdentity(IdentityRequest request, ServerCallContext context)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        
        if (user is null)
        {
            return new GetIdentityResponse
            {
                Empty = new Empty()
            };
        }

        return new GetIdentityResponse
        {
            Identity = new IdentityReply
            {
                Id = user.Id,
                Name = user.FullName,
                Image = user.Image
            }
        };
    }
    
}