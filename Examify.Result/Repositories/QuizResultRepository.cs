using Examify.Quiz.Dtos;
using Examify.Result.Dtos;
using Examify.Result.Entities;
using Examify.Result.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Result;
using QuizResult = Examify.Result.Entities.QuizResult;

namespace Examify.Result.Repositories;

public class QuizResultRepository(
    QuizResultContext quizResultContext,
    Identity.IdentityClient identityClient,
    QuizGrpcService.QuizGrpcServiceClient quizClient,
    ILogger<QuizResultRepository> logger
)
    : IQuizResultRepository
{
    public async Task<QuizResult> Create(string userId, string quizId, int attemptedNumber)
    {
        QuizResult quizResult = new QuizResult
        {
            UserId = userId,
            QuizId = Guid.Parse(quizId),
            AttemptedNumber = attemptedNumber,
            TotalPoints = 0,
            TimeTaken = 0,
            CurrentQuestion = 0,
        };

        await quizResultContext.QuizResults.AddAsync(quizResult);

        return quizResult;
    }

    // get quizResult sorted by question order and answer order
    public async Task<QuizResult?> FindByIdWithQuestionsWithOptions(Guid id)
    {
        return await quizResultContext.QuizResults
            .AsNoTracking()
            .Include(r => r.QuestionResults)
            .ThenInclude(q => q.AnswerResults)
            .Where(r => r.Id == id)
            .Select(r => new QuizResult
            {
                Id = r.Id,
                UserId = r.UserId,
                QuizId = r.QuizId,
                AttemptedNumber = r.AttemptedNumber,
                TotalPoints = r.TotalPoints,
                TimeTaken = r.TimeTaken,
                CurrentQuestion = r.CurrentQuestion,
                QuestionResults = r.QuestionResults
                    .OrderBy(q => q.Order)
                    .Select(q => new QuestionResult
                    {
                        Id = q.Id,
                        Order = q.Order,
                        IsCorrect = q.IsCorrect,
                        Points = q.Points,
                        TimeTaken = q.TimeTaken,
                        SubmittedAt = q.SubmittedAt,
                        QuestionId = q.QuestionId,
                        AnswerResults = q.AnswerResults
                            .OrderBy(a => a.Order)
                            .ToList()
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<QuizResult?> FindById(Guid id)
    {
        return await quizResultContext.QuizResults
            .AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> Update(QuizResult quizResult)
    {
        quizResultContext.QuizResults.Update(quizResult);
        return true;
    }

    public async Task<bool> Exists(Guid quizResultId)
    {
        return await quizResultContext.QuizResults.AnyAsync(q => q.Id == quizResultId);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await quizResultContext.SaveChangesAsync() > 0;
    }

    public async Task<int> CountQuizAttempts(Guid Id, CancellationToken cancellationToken)
    {
        return await quizResultContext.QuizResults.Where(x => x.QuizId == Id).CountAsync();
    }

    public async Task<int> GetLatestAttemptNumber(Guid quizId, string userId, CancellationToken cancellationToken)
    {
        return await quizResultContext.QuizResults
            .Where(x => x.QuizId == quizId && x.UserId == userId)
            .Select(x => x.AttemptedNumber)
            .OrderByDescending(x => x)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<GetQuizResultsDto>> GetResultsOfQuiz(string quizId)
    {
        List<QuizResult> quizResults = await quizResultContext.QuizResults
            .AsNoTracking()
            .Include(r => r.QuestionResults)
            .ThenInclude(q => q.AnswerResults)
            .Where(r => r.QuizId.ToString() == quizId)
            .ToListAsync();

        List<GetQuizResultsDto> quizResultsDto = new();

        foreach (var quizResult in quizResults)
        {
            var user = identityClient.GetIdentity(new IdentityRequest { Id = quizResult.UserId });

            double correctRate = quizResult.QuestionResults.Count(q => q.IsCorrect) * 1.0 / quizResult.QuestionResults.Count;

            var quizResultDto = new GetQuizResultsDto
            {
                Id = quizResult.Id,
                TotalPoints = quizResult.TotalPoints,
                TimeTaken = quizResult.TimeTaken,
                AttemptedNumber = quizResult.AttemptedNumber,
                SubmittedAt = quizResult.SubmittedAt,
                CorrectRate = correctRate,
                User = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Avatar = user.Image
                }
            };

            quizResultsDto.Add(quizResultDto);
        }

        return quizResultsDto;
    }

    public async Task<List<UserResultsDetailsDto>> GetQuizResultsByQuizAndUser(string quizId, string userId)
    {
        List<QuizResult> quizResults = await quizResultContext.QuizResults
            .AsNoTracking()
            .Include(r => r.QuestionResults)
            .ThenInclude(q => q.AnswerResults)
            .Where(r => r.QuizId == Guid.Parse(quizId) && r.UserId == userId)
            .Select(r => new QuizResult
            {
                Id = r.Id,
                UserId = r.UserId,
                QuizId = r.QuizId,
                AttemptedNumber = r.AttemptedNumber,
                TotalPoints = r.TotalPoints,
                TimeTaken = r.TimeTaken,
                CurrentQuestion = r.CurrentQuestion,
                QuestionResults = r.QuestionResults
                    .OrderBy(q => q.Order)
                    .Select(q => new QuestionResult
                    {
                        Id = q.Id,
                        Order = q.Order,
                        IsCorrect = q.IsCorrect,
                        Points = q.Points,
                        TimeTaken = q.TimeTaken,
                        SubmittedAt = q.SubmittedAt,
                        QuestionId = q.QuestionId,
                        AnswerResults = q.AnswerResults
                            .OrderBy(a => a.Order)
                            .ToList()
                    })
                    .ToList()
            })
            .ToListAsync();

        List<UserResultsDetailsDto> userResultsDetailsDtos = new();

        if (quizResults.Count == 0)
        {
            return userResultsDetailsDtos;
        }

        var populatedQuiz = quizClient.GetQuiz(new QuizRequest
        {
            Id = quizId
        });

        foreach (var quizResult in quizResults)
        {
            var user = identityClient.GetIdentity(new IdentityRequest { Id = quizResult.UserId });

            var userResultsDetailsDto = new UserResultsDetailsDto
            {
                Id = quizResult.Id,
                TotalPoints = quizResult.TotalPoints,
                TimeTaken = quizResult.TimeTaken,
                AttemptedNumber = quizResult.AttemptedNumber,
                SubmittedAt = quizResult.SubmittedAt,
                Quiz = new QuizDataDto
                {
                    Id = quizId,
                    Title = populatedQuiz.Title,
                    Description = populatedQuiz.Description
                },
                User = new UserDataDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Avatar = user.Image
                },
                QuestionResults = quizResult.QuestionResults.Select(qr => new QuestionResultDataDto()
                {
                    Id = qr.Id,
                    Order = qr.Order,
                    IsCorrect = qr.IsCorrect,
                    Points = qr.Points,
                    TimeTaken = qr.TimeTaken,
                    Question = populatedQuiz.Questions
                            .FirstOrDefault(q => Guid.Parse(q.Id) == qr.QuestionId)
                        is QuizQuestionMessage question
                        ? new QuestionDataDto
                        {
                            Id = question.Id,
                            Content = question.Content,
                            Type = question.Type,
                            Duration = question.Duration,
                            Points = question.Points
                        }
                        : new QuestionDataDto
                        {
                            Id = string.Empty,
                            Content = string.Empty,
                            Type = string.Empty,
                            Duration = 0,
                            Points = 0
                        },
                    AnswerResults = qr.AnswerResults.Select(ar => new AnswerResultDataDto
                    {
                        Id = ar.Id,
                        Order = ar.Order,
                        IsSelected = ar.IsSelected,
                        Option = populatedQuiz.Questions
                                .SelectMany(q => q.Options)
                                .FirstOrDefault(o => Guid.Parse(o.Id) == ar.OptionId)
                            is QuizOptionMessage option
                            ? new OptionDataDto
                            {
                                Id = option.Id,
                                Content = option.Content,
                                IsCorrect = option.IsCorrect,
                            }
                            : new OptionDataDto
                            {
                                Id = string.Empty,
                                Content = string.Empty,
                            }
                    }).ToList()
                }).ToList()
            };

            userResultsDetailsDtos.Add(userResultsDetailsDto);
        }

        return userResultsDetailsDtos;
    }

    public async Task<List<QuizRecentActivityDto>> GetListRecentActivity(string userId, int pageNumber, int pageSize)
    {
        var Ids = await quizResultContext.QuizResults
            .Include(x => x.QuestionResults)
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.SubmittedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var quizzes = new List<QuizRecentActivityDto>();

        foreach (var record in Ids)
        {
            var quiz = await quizClient.GetQuizAsync(new QuizRequest { Id = record.QuizId.ToString() });
            quizzes.Add(new QuizRecentActivityDto
            {
                Id = record.Id,
                QuizId = record.QuizId,
                Title = quiz.Title,
                Description = quiz.Description,
                Code = quiz.Code,
                Cover = quiz.Cover,
                QuestionCount = quiz.Questions.Count,
                CurrentProgress = (decimal)record.QuestionResults.Count(x => x.SubmittedAt != DateTime.MinValue) / record.QuestionResults.Count * 100
            });
        }

        return quizzes;
    }
    
	public async Task<GetLeaderBoardDto> GetStartQuiz(string Code)
	{
		var populatedQuiz = quizClient.GetQuiz(new QuizRequest
		{
			Code = Code,
			Id = ""
		});

		var playTime = DateTime.SpecifyKind(DateTime.Parse(populatedQuiz.PlayTime), DateTimeKind.Utc);

		var listQuizResult = await quizResultContext.QuizResults
			.Where(quiz => quiz.QuizId == Guid.Parse(populatedQuiz.Id))
			.Where(quiz => quiz.CreatedDate >= playTime)
			.ToListAsync();

		List<UserStartQuizDto> listUsers = new();
		List<QuestionStartQuizDto> listQuestions = new();

		foreach (var item in listQuizResult)
		{
			var user = identityClient.GetIdentity(new IdentityRequest { Id = item.UserId });
			UserStartQuizDto userStartQuizDto = new UserStartQuizDto
			{
				Id = user.Id,
				Name = user.Name,
				Score = item.TotalPoints,
				Image = user.Image
			};
			listUsers.Add(userStartQuizDto);
		}

		foreach (var questionQuiz in populatedQuiz.Questions)
		{
			var correctOption = questionQuiz.Options.FirstOrDefault(o => o.IsCorrect);
			if (correctOption == null)
			{
				continue; // Skip this question if there is no correct option
			}

			var correctOptionId = Guid.Parse(correctOption.Id);

            var correctCount = await quizResultContext.QuizResults
                .Where(quiz => quiz.QuestionResults.Any(question => question.QuestionId == Guid.Parse(questionQuiz.Id) && question.IsCorrect))
                .CountAsync();

			var incorrectCount = await quizResultContext.QuizResults
	            .Where(quiz => quiz.QuestionResults.Any(question =>
		            question.QuestionId == Guid.Parse(questionQuiz.Id) && question.IsCorrect == false))
	            .Where(quiz => quiz.QuestionResults.Any(question =>
		            question.AnswerResults.Any(answer => answer.IsSelected)))
	            .CountAsync();

			var totalAnswers = correctCount + incorrectCount;
			var correctPercentage = totalAnswers > 0 ? (double)correctCount / totalAnswers * 100 : 0;

			var question = new QuestionStartQuizDto
			{
				Id = questionQuiz.Id,
				Title = questionQuiz.Content,
				Description = questionQuiz.Content,
				Type = questionQuiz.Type,
				Progress = 0,
				Correct = correctCount,
				Incorrect = incorrectCount,
				Options = questionQuiz.Options.Select(option => new Dtos.OptionDto
				{
					Id = option.Id,
					Content = option.Content,
					IsCorrect = option.IsCorrect
				}).ToList()
			};
			listQuestions.Add(question);
		}

		GetLeaderBoardDto getLeaderBoardDto = new GetLeaderBoardDto
		{
			users = listUsers,
			questions = listQuestions
		};

		return getLeaderBoardDto;
	}
}