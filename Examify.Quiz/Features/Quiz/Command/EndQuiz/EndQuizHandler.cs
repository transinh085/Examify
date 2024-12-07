using Examify.Events;
using Examify.Quiz.Repositories.Quiz;
using MassTransit;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.EndQuiz;

public class EndQuizHandler(IQuizRepository quizRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<EndQuizCommand, IResult>
{
    public async Task<IResult> Handle(EndQuizCommand request, CancellationToken cancellationToken)
    {
        await quizRepository.EndQuiz(request.QuizId, cancellationToken);
        EndExamEvent endExamEvent = new EndExamEvent
		{
			ExamId = request.QuizId
		};
		await publishEndpoint.Publish(endExamEvent);
		return TypedResults.Ok();
    }
}