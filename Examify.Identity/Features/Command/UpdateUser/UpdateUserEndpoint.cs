using System.Security.Claims;
using Examify.Core.Endpoints;
using Examify.Identity.Dtos;
using MediatR;

namespace Examify.Identity.Features.Command.UpdateUser;

public class UpdateUserEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
            app.MapPut("/users",
                    async (ClaimsPrincipal user, ISender sender,UpdateUserRequest request) =>
            {
                var userId = user.Identity?.Name;

                if (string.IsNullOrEmpty(userId))
                {
                    return TypedResults.Unauthorized();
                }
                var result = await sender.Send(new UpdateUserCommand(userId,request.FirstName,request.LastName));
                return result;
            })
            .Produces<AppUserDto>()
            .RequireAuthorization()
            .WithTags("Users");
    }
}

public class UpdateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}