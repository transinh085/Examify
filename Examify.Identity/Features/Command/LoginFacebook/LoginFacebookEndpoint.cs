using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.Command.LoginFacebook;

public class LoginFacebookEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/login/facebook",
            async (LoginFacebookCommand command, ISender sender) => await sender.Send(command));
    }
}