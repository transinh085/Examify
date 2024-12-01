using Examify.Core.Endpoints;
using Examify.Quiz.Dtos;
using MediatR;

namespace Examify.Result.Features.Query.GetUsersResultsDetails;

public class GetUsersResultsDetailsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quiz/{quizId}/users/{userId}/quiz-results", 
                async (ISender sender, string quizId, string userId) => 
                    await sender.Send(new GetUsersResultsDetailsQuery(quizId, userId)))
            .Produces<UserResultsDetailsDto>()
            .WithTags("Quiz Results")
            .RequireAuthorization();
    }
}