using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.Command.UpdatePassword;

public class UpdatePasswordEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/update-password",
                async (ClaimsPrincipal user, ISender sender, UpdatePasswordRequest request) =>
                {
                    // Lấy user ID từ Claims
                    var userId = user.Identity?.Name;

                    if (string.IsNullOrEmpty(userId))
                    {
                        return TypedResults.Unauthorized();
                    }

                    // Gửi lệnh qua MediatR
                    var result =
                        await sender.Send(new UpdatePasswordCommand(userId, request.OldPassword, request.NewPassword));
                    return result;
                })
            .WithTags("Authentication")
            .RequireAuthorization();
    }
}