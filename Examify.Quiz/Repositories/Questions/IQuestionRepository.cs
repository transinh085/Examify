using Examify.Quiz.Dtos;
using Examify.Quiz.Features.Questions.Command.BulkUpdateQuestion;
using Examify.Quiz.Features.Questions.Command.PatchQuestionAttributes;

namespace Examify.Quiz.Repositories.Questions;

public interface IQuestionRepository
{
    Task BulkUpdateQuestion(BulkUpdateQuestionCommand request, CancellationToken cancellationToken);
    Task CreateQuestion(Entities.Question question, CancellationToken cancellationToken);
    
    Task DeleteQuestionById(Guid questionId, CancellationToken cancellationToken);
    
    Task DuplicateQuestion(Guid questionId, CancellationToken cancellationToken);
    Task PatchQuestionAttributes(PatchQuestionAttributesCommand request, CancellationToken cancellationToken);
    Task<bool> IsQuestionExists(Guid id, CancellationToken cancellationToken);
    
    Task<PopulatedQuestionDto?> FindById(Guid id);

}