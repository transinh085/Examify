using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Questions.Query.GetQuestionsByQuizId;

public class GetQuesionsByQuizIdEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("quizzes/{quizId}/questions", async (Guid quizId, ISender sender) =>
            await sender.Send(new GetQuesionsByQuizIdQuery(quizId))
        ).WithTags("Questions");
    }
}