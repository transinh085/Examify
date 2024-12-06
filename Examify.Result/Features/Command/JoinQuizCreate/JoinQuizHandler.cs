using Examify.Events;
using Examify.Result.Entities;
using Examify.Result.Repositories;
using MassTransit;
using MediatR;
using Result;

namespace Examify.Result.Features.Command.JoinQuizCreate;

public class JoinQuizHandler (
	IJoinQuizRepository joinQuizRepository,
	QuizGrpcService.QuizGrpcServiceClient quizClient,
	IPublishEndpoint publishEndpoint,
	ILogger<JoinQuizHandler> logger
    ) : IRequestHandler<JoinQuizCommand, IResult>
{
    public async Task<IResult> Handle(JoinQuizCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating quiz result of quiz {QuizCode} for user {UserId}", request.Code, request.UserId);
        var populatedQuiz = quizClient.GetQuiz(new QuizRequest
        {
            Id = "",
            Code = request.Code
        });

        if (populatedQuiz == null) { 
            return TypedResults.NotFound("Quiz not found");
		}

        bool checkUserJoin = await joinQuizRepository.CheckUserJoin(Guid.Parse(request.UserId), request.Code);

        if (!checkUserJoin)
        {

			JoinQuiz joinQuiz = await joinQuizRepository.Create(Guid.Parse(request.UserId), Guid.Parse(populatedQuiz.Id));

			var userJoinedExamEvent = new UserJoinedExamEvent
			{
				UserId = request.UserId,
				ExamId = Guid.Parse(populatedQuiz.Id)
			};
			await publishEndpoint.Publish(userJoinedExamEvent);
		}

		return Results.Ok(new
        {
			Code = request.Code,
			Message = "Join quiz success"
		}); 
    }
}