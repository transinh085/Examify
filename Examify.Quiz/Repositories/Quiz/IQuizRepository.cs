using Examify.Core.Pagination;
using Examify.Quiz.Dtos;
using Examify.Quiz.Features.Quiz.Dtos;

namespace Examify.Quiz.Repositories.Quiz;

public interface IQuizRepository
{
    Task<Entities.Quiz> CreateQuizEmpty(string userId, CancellationToken cancellationToken);

    Task<Entities.Quiz> FindQuizById(Guid id, CancellationToken cancellationToken);

    Task DeleteQuizById(Guid id, CancellationToken cancellationToken);

    Task<bool> IsQuizExists(Guid id, CancellationToken cancellationToken);

    Task PublishQuiz(Guid id, CancellationToken cancellationToken);

    Task UpdateQuiz(Entities.Quiz quiz, CancellationToken cancellationToken);

    Task<List<QuizDto>> GetAllQuizzes(CancellationToken cancellationToken);

    Task<PagedList<QuizItemResponseDto>> GetQuizByUserId(string userId, bool isPublish, int pageNumber, int pageSize,
        CancellationToken cancellationToken);

    Task<PopulatedQuizDto?> GetQuizById(string quizId);

    Task<PopulatedQuizDto?> GetQuizByCode(string code);

    Task PlayQuiz(Guid id, CancellationToken cancellationToken);
    Task EndQuiz(Guid id, CancellationToken cancellationToken);

    Task<PagedList<QuizItemResponseDto>> SearchQuizzes(string? keyword, Guid? subjectId, int pageNumber, int pageSize,
        CancellationToken cancellationToken);

    Task StartQuiz(Guid id, CancellationToken cancellationToken);
}