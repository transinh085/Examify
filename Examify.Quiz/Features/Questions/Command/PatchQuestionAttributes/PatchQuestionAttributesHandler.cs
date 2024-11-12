using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Questions;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.PatchQuestionAttributes;

public class PatchQuestionAttributesHandler(IQuestionRepository questionRepository)
    : IRequestHandler<PatchQuestionAttributesCommand, IResult>
{
    public async Task<IResult> Handle(PatchQuestionAttributesCommand request, CancellationToken cancellationToken)
    {
        await questionRepository.PatchQuestionAttributes(request, cancellationToken);
        return TypedResults.NoContent();
    }
}