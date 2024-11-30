using Examify.Identity.Repositories;
using Grpc.Core;
using Identity;

namespace Examify.Identity.Grpc;

public class IdentityService(IUserRepository userRepository) : global::Identity.Identity.IdentityBase
{
    public override async Task<IdentityReply> GetIdentity(IdentityRequest request, ServerCallContext context)
    {
        var user = await userRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
        }

        return await Task.FromResult(new IdentityReply
        {
            Id = user.Id,
            Name = user.FullName,
            Image = user.Image
        });
    }
}