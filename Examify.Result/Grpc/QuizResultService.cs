using Examify.Result.Repositories.QuizResults;
using Grpc.Core;
using Result;

namespace Examify.Result.Grpc;

public class QuizResultService(IQuizResultRepository repository) : QuizResult.QuizResultBase
{
    public override async Task<QuizAttemptsReply> CountQuizAttempts(QuizAttemptsRequest request,
        ServerCallContext context)
    {
        var count = await repository.CountQuizAttempts(new Guid(request.Id), context.CancellationToken);
        return new QuizAttemptsReply
        {
            Id = request.Id,
            Attempts = count
        };
    }
}