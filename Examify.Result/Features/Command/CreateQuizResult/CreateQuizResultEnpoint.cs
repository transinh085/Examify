using System.Security.Claims;
using Examify.Core.Endpoints;
using Examify.Result.Entities;
using MediatR;

namespace Examify.Quiz.Features.Result.Command.CreateQuizResult;

public class CreateQuizResultEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/quizzes/{quizId}/quiz-results",
                async (ClaimsPrincipal user, ISender sender, CreateQuizResultCommand command, string quizId) => 
                    await sender.Send(command with { QuizId = quizId, UserId = user.Identity.Name }))
            .Produces<QuizResult>()
            .WithTags("Quiz Results")
            .RequireAuthorization();
    }
}