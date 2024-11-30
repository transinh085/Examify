using Examify.Quiz.Features.Quiz.Dtos;

namespace Examify.Quiz.Grpc;

public interface IQuizMetaService
{
    Task<SubjectDto> GetSubjectAsync(Guid? Id);
    Task<LanguageDto> GetLanguageAsync(Guid? Id);
    Task<OwnerDto> GetOwnerAsync(Guid? Id);
    Task<GradeDto> GetGradeAsync(Guid? Id);
    Task<int> CountQuizAttemptsAsync(Guid? quizId);
}