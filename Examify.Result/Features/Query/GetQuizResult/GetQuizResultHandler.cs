using Examify.Quiz.Dtos;
using Examify.Result.Entities;
using Examify.Result.Repositories;
using MediatR;
using Result;

namespace Examify.Result.Features.Query.GetQuizResult;

public class GetQuizResultHandler(
    IQuizResultRepository quizResultRepository,
    global::Result.Quiz.QuizClient quizClient
) : IRequestHandler<GetQuizResultQuery, IResult>
{
    public async Task<IResult> Handle(GetQuizResultQuery request, CancellationToken cancellationToken)
    {
        QuizResult? quizResult = await quizResultRepository.FindById(request.Id);

        if (quizResult == null)
        {
            return TypedResults.NotFound("Result not found.");
        }

        var populatedQuiz = quizClient.GetQuiz(new QuizRequest
        {
            Id = quizResult.QuizId.ToString(),
        });

        var quizResultDto = new GetQuizResultDto
        {
            Id = quizResult.Id,
            QuestionResults = quizResult.QuestionResults.Select(qr => new QuestionResultDto
            {
                Id = qr.Id,
                IsCorrect = qr.IsCorrect,
                Question = populatedQuiz.Questions
                        .FirstOrDefault(q => Guid.Parse(q.Id) == qr.QuestionId)
                    is Question question
                    ? new QuestionDto
                    {
                        Id = question.Id,
                        Content = question.Content,
                        Duration = question.Duration,
                        Points = question.Points
                    }
                    : new QuestionDto
                    {
                        Id = string.Empty,
                        Content = string.Empty,
                        Duration = 0,
                        Points = 0
                    },
                AnswerResults = qr.AnswerResults.Select(ar => new AnswerResultDto
                {
                    Id = ar.Id,
                    IsSelected = ar.IsSelected,
                    Options = populatedQuiz.Questions
                            .SelectMany(q => q.Options)
                            .FirstOrDefault(o => Guid.Parse(o.Id) == ar.OptionId)
                        is Option option
                        ? new OptionDto
                        {
                            Id = option.Id,
                            Content = option.Content,
                            IsCorrect = option.IsCorrect
                        }
                        : new OptionDto
                        {
                            Id = string.Empty,
                            Content = string.Empty,
                            IsCorrect = false
                        }
                }).ToList()
            }).ToList()
        };
        return TypedResults.Ok(quizResultDto);
    }
}