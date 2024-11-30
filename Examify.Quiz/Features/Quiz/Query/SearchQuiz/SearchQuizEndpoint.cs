using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.SearchQuiz;

public class SearchQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quizzes/search",
            async ([AsParameters] SearchQuizQuery query, ISender sender) => await sender.Send(query));
    }
}