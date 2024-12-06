using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.PlayQuiz;

public class PlayQuizHandler(IQuizRepository quizRepository) : IRequestHandler<PlayQuizCommand, IResult>
{
    public async Task<IResult> Handle(PlayQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await quizRepository.FindQuizById(request.QuizId, cancellationToken);
        if(quiz == null)
		{
			return TypedResults.NotFound("Quiz not found");
		}
        if(quiz.PlayTime == null) await quizRepository.PlayQuiz(request.QuizId, cancellationToken);
        return TypedResults.Ok();
    }
}