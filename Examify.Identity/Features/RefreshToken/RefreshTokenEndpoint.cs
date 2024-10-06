using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.RefreshToken;

public class RefreshTokenEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/refresh-token", async (RefreshTokenCommand command, ISender sender) =>
            await sender.Send(command)
        ).WithTags("Authentication");
    }
}