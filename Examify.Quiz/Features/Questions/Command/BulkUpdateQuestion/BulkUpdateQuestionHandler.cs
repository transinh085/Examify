using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Command.BulkUpdateQuestion;

public class BulkUpdateQuestionHandler(IQuestionRepository questionRepository) : IRequestHandler<BulkUpdateQuestionCommand, IResult>
{
    public async Task<IResult> Handle(BulkUpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        await questionRepository.BulkUpdateQuestion(request, cancellationToken);
        return TypedResults.NoContent();
    }
}