using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.OrderQuestion;

public class OrderQuestionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("questions/{questionId:guid}/order",
                async (Guid questionId, OrderQuestionCommand request, ISender sender,
                    CancellationToken cancellationToken, ILogger<OrderQuestionEndpoint> logger) =>
                {
                    logger.LogInformation($"OrderQuestionEndpoint - questionId: {questionId}, Order: {request.Order}");
                    return await sender.Send(request with { QuestionId = questionId }, cancellationToken);
                })
            .Produces<IResult>(StatusCodes.Status204NoContent);
    }
}