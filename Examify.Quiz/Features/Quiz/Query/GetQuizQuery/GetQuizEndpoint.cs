using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizQuery;

public class GetQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quizzes/{id}", async (ISender sender, Guid id) => await sender.Send(new GetQuizQuery(id)))
            .Produces<Entities.Quiz>();
    }
}