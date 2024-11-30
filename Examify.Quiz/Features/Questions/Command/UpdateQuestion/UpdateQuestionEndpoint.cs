using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.UpdateQuestion;

public class UpdateQuestionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("questions/{Id:guid}",
                async (Guid Id, UpdateQuestionCommand request, ISender sender,
                    CancellationToken cancellationToken, ILogger<UpdateQuestionEndpoint> logger) =>
                {
                    logger.LogInformation($"UpdateQuestionEndpoint - questionId: {Id}");
                    return await sender.Send(request with { Id = Id }, cancellationToken);
                })
            .Produces<IResult>(StatusCodes.Status204NoContent);
    }
}