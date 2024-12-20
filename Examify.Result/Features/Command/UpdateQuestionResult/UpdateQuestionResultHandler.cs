﻿using Examify.Events;
using Examify.Result.Repositories.AnswerResults;
using Examify.Result.Repositories.QuestionResults;
using Examify.Result.Repositories.QuizResults;
using MassTransit;
using MediatR;
using Result;

namespace Examify.Result.Features.Command.UpdateQuestionResult;

public class UpdateQuestionResultHandler(
    IQuizResultRepository quizResultRepository,
    IQuestionResultRepository questionResultRepository,
    IAnswerResultRepository answerResultRepository,
    QuestionGrpcService.QuestionGrpcServiceClient questionGrpcServiceClient,
    IPublishEndpoint publishEndpoint)
    : IRequestHandler<UpdateQuestionResultCommand, IResult>
{
    public async Task<IResult> Handle(UpdateQuestionResultCommand request, CancellationToken cancellationToken)
    {
        var questionResult = await questionResultRepository.FindById(request.QuestionResultId);

        if (questionResult == null)
        {
            return Results.NotFound("Question result not found");
        }

        var populatedQuestion = questionGrpcServiceClient.GetQuestion(new QuestionRequest
        {
            Id = questionResult.QuestionId.ToString(),
        });

        // save answers
        foreach (var requestAnswer in request.Answers)
        {
            var answerResult =
                await answerResultRepository.FindByQuestionResultIdAndOptionId(request.QuestionResultId,
                    Guid.Parse(requestAnswer));
            answerResult.IsSelected = true;
            await answerResultRepository.Update(answerResult);
        }

        // compare answers to calculate points

        var correctAnswers = populatedQuestion.Options
            .Where(o => o.IsCorrect)
            .Select(o => o.Id)
            .ToHashSet();

        var areEqual = correctAnswers.SetEquals(request.Answers);

        questionResult.IsCorrect = areEqual;
        questionResult.Points = areEqual ? populatedQuestion.Points : 0;
        questionResult.TimeTaken = request.TimeTaken;
        questionResult.SubmittedAt = DateTime.UtcNow;

        await questionResultRepository.Update(questionResult);

        // update currentQuestion and timeTaken of quizResult
        var quizResult = await quizResultRepository.FindById(questionResult.QuizResultId);

        if (quizResult is not null)
        {
            quizResult.CurrentQuestion++;
            quizResult.TotalPoints += questionResult.Points;
            quizResult.TimeTaken = request.TimeSpent;
            quizResult.SubmittedAt = DateTime.UtcNow;
            await quizResultRepository.Update(quizResult);
        }

        await quizResultRepository.SaveChangesAsync();

        await publishEndpoint.Publish(new UpdateExamEvent
        {
            ExamId = quizResult.QuizId
        });

        return Results.Ok(new
        {
            IsCorrect = areEqual,
            CorrectOptions = correctAnswers,
        });
    }
}