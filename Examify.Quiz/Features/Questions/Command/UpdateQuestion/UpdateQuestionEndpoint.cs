using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.UpdateQuestion;

public class UpdateQuestionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("questions/{id:guid}",
                async (Guid id, UpdateQuestionCommand request, ISender sender, CancellationToken cancellationToken) =>
                     await sender.Send(request with { Id = id }, cancellationToken)
                )
            .Produces<IResult>(StatusCodes.Status204NoContent);
    }
}