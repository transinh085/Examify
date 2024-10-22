using Examify.Core.Endpoints;
using Examify.Identity.Dtos;
using MediatR;

namespace Examify.Identity.Features.GetUsers;

public class GetUsersEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users", (ISender sender) => sender.Send(new GetUsersQuery()))
            .Produces<IEnumerable<AppUserDto>>()
            .WithTags("Users");
    }
}