using AutoMapper;
using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.UpdateQuizMore;

public class UpdateQuizPHandler(IQuizRepository quizRepository, IMapper mapper) : IRequestHandler<UpdateQuizPCommand, IResult>
{
    public async Task<IResult> Handle(UpdateQuizPCommand request, CancellationToken cancellationToken)
    {
        var findQuiz = await quizRepository.FindQuizById(request.Id, cancellationToken);
        if (findQuiz == null)
        {
            return TypedResults.NotFound("Quiz not found");
        }

        findQuiz.StartTime =DateTime.Parse(request.StartTime);
        findQuiz.EndTime = DateTime.Parse(request.EndTime);
        findQuiz.RandomQuestions = request.RandomQuestions;
        findQuiz.RandomOptions = request.RandomOptions;
        quizRepository.UpdateQuiz(findQuiz, cancellationToken);
        return TypedResults.Ok(findQuiz);
    }
}