using Examify.Result.Repositories;
using MediatR;

namespace Examify.Result.Features.Command.DeleteQuizResult;

public class DeleteQuizResultHandler(IQuizResultRepository quizResultRepository) : IRequestHandler<DeleteQuizResultCommand, IResult>
{
    public async Task<IResult> Handle(DeleteQuizResultCommand request, CancellationToken cancellationToken)
    {
        await quizResultRepository.DeleteResultById(request.Id);
        return TypedResults.NoContent();
    }
}
