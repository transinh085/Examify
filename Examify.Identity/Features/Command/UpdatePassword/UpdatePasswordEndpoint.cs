using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.Command.UpdatePassword;

public class UpdatePasswordEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/updatepassword", async (UpdatePasswordCommand command,ISender sender) =>
        {
            var result = await sender.Send(command);
            return result;
        }).WithTags("Authentication")
        .RequireAuthorization();
    }
}