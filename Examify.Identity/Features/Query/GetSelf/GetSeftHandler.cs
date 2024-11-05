using System.Security.Claims;
using Examify.Core.Reponse;
using Examify.Identity.Features.Query.GetUsers;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.GetSelf;

public class GetSeftHandler(IUserRepository userRepository) : IRequestHandler<GetSeftQuery, IResult>
{
    public async Task<IResult> Handle(GetSeftQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.username);
        if (user == null)
        {
            return BaseResponse.SendFail("User not found");
        }
        GetSelfResponse getSelfResponse = new GetSelfResponse
        {
            Email = user.Email,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FullName = user.FullName,
            Image = user.Image
        };
        return BaseResponse.SendSuccess(getSelfResponse, "Get info succcessful");
    }
}