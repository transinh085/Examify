﻿
using Examify.Quiz.Features.Quiz.Dtos;

namespace Examify.Quiz.Repositories.Quiz;

public interface IQuizRepository
{
    Task<Entities.Quiz> CreateQuizEmpty(string userId,CancellationToken cancellationToken);
    
    Task<Entities.Quiz> FindQuizById(Guid id, CancellationToken cancellationToken);
    Task DeleteQuizById (Guid id,  CancellationToken cancellationToken);
    
    Task<bool> IsQuizExists(Guid id, CancellationToken cancellationToken);
    
    Task PublishQuiz(Guid id, CancellationToken cancellationToken);
    
    Task UpdateQuiz(Entities.Quiz quiz, CancellationToken cancellationToken);
    
    Task<List<QuizDto>> GetAllQuizzes(CancellationToken cancellationToken);
    
    Task<QuizUserDto> GetQuizByUserId(Guid userId, CancellationToken cancellationToken);
}