using System.Security.Claims;
using Examify.Core.Endpoints;
using Examify.Identity.Dtos;
using MediatR;

namespace Examify.Identity.Features.Command.UpdateUserImage;

public class UpdateUserImageEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/users/image",
                async (ClaimsPrincipal user, ISender sender,UpdateUserImageRequest request) =>
                {
                    var userId = user.Identity?.Name;

                    if (string.IsNullOrEmpty(userId))
                    {
                        return TypedResults.Unauthorized();
                    }
                    var result = await sender.Send(new UpdateUserImageCommand(userId,request.Image));
                    return result;
                })
            .Produces<AppUserDto>()
            .RequireAuthorization()
            .WithTags("Users");
    }
}

public class UpdateUserImageRequest
{
    public string Image { get; set; }
}