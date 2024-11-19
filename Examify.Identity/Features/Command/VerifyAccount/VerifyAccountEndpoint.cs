using Examify.Core.Endpoints;
using Examify.Identity.Dtos;
using MediatR;

namespace Examify.Identity.Features.Command.VerifyAccount;

public class VerifyAccountEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/verify-account", async (VerifyAccountCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return result;
            })
            .Produces<AppUserDto>()
            .WithTags("Authentication");
    }
}