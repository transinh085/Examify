using Examify.Events;
using Examify.Quiz.Repositories.Quiz;
using MassTransit;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.StartQuiz;

public class StartQuizHandler(IQuizRepository quizRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<StartQuizCommand, IResult>
{
    public async Task<IResult> Handle(StartQuizCommand request, CancellationToken cancellationToken)
    {
        await quizRepository.StartQuiz(request.QuizId, cancellationToken);
		StartExamEvent startExamEvent = new StartExamEvent
        {
			ExamId = request.QuizId
		};
		await publishEndpoint.Publish(startExamEvent);
		return TypedResults.Ok();
    }
}