using Examify.Quiz.Entities;
using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Questions;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.DeleteQuestion;

public class DeleteQuestionHandler(IQuestionRepository questionRepository) : IRequestHandler<DeleteQuestionCommand, IResult>
{
    public async Task<IResult> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        await questionRepository.DeleteQuestionById(request.Id, cancellationToken);
        return TypedResults.NoContent();
    }
}