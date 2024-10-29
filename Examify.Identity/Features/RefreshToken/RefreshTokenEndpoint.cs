using Examify.Core.Endpoints;
using Examify.Identity.Features.Login;
using MediatR;

namespace Examify.Identity.Features.RefreshToken;

public class RefreshTokenEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/refresh-token", async (RefreshTokenCommand command, ISender sender) =>
                await sender.Send(command)
            )
            .Produces<AuthenticationResponse>()
            .WithTags("Authentication");
    }
}