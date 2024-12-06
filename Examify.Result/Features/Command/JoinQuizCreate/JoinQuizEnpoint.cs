using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examify.Result.Features.Command.JoinQuizCreate;

public class JoinQuizEndpoint : IEndpoint
{
	public void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapPost("/join-quiz",
				async ([FromBody] JoinQuizRequest request, ClaimsPrincipal user, ISender sender) =>
					await sender.Send(new JoinQuizCommand(request.Code, user.Identity.Name)))
			.WithTags("Quiz Results")
			.RequireAuthorization();
	}
}

public class JoinQuizRequest
{
	public string Code { get; set; }
}
