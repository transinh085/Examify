﻿using Examify.Core.Endpoints;
using Examify.Identity.Dtos;
using MediatR;

namespace Examify.Identity.Features.Login;

public class LoginEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/login", async (LoginCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return result;
            })
            .Produces<AuthenticatedDto>()
            .WithTags("Authentication");
    }
}