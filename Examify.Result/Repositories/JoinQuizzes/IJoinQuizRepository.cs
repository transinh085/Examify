using Examify.Quiz.Dtos;
using Examify.Result.Entities;

namespace Examify.Result.Repositories.JoinQuizzes
{
    public interface IJoinQuizRepository
    {
        Task<JoinQuiz> Create(Guid userId, Guid quizId);

        Task<List<UserDto>> GetUserJoinQuiz(string Code);

        Task<bool> CheckUserJoin(Guid userId, string code);
    }
}
