﻿using Examify.Core.Pagination;
using Examify.Quiz.Dtos;
using Examify.Result.Dtos;
using Examify.Result.Entities;

namespace Examify.Result.Repositories.QuizResults;

public interface IQuizResultRepository
{
    Task<QuizResult> Create(string userId, string quizId, int attemptedNumber);

    Task<QuizResult?> FindByIdWithQuestionsWithOptions(Guid id);

    Task<QuizResult?> FindById(Guid id);

    Task<bool> Update(QuizResult quizResult);

    Task<bool> Exists(Guid quizResultId);

    Task<bool> SaveChangesAsync();

    Task<int> CountQuizAttempts(Guid Id, CancellationToken cancellationToken);

    Task<int> GetLatestAttemptNumber(Guid quizId, string userId, CancellationToken cancellationToken);

    Task<List<GetQuizResultsDto>> GetResultsOfQuiz(string quizId);

    Task<List<UserResultsDetailsDto>> GetQuizResultsByQuizAndUser(string quizId, string userId);

    Task<PagedList<QuizRecentActivityDto>> GetListRecentActivity(string userId, string isCompleted, int pageNumber, int pageSize);

    Task<GetLeaderBoardDto> GetStartQuiz(string Code);

    Task<bool> DeleteAllResultsOfQuiz(Guid quizId);

    Task<bool> DeleteResultById(Guid id);
}
