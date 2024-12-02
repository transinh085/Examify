using Examify.Quiz.Features.Quiz.Dtos;
using Quiz;
using Result;

namespace Examify.Quiz.Grpc;

public class QuizMetaService(
    Subject.SubjectClient subjectClient,
    Language.LanguageClient languageClient,
    Identity.IdentityClient identityClient,
    Grade.GradeClient gradeClient,
    QuizResult.QuizResultClient quizResultClient
) : IQuizMetaService
{
    public Task<SubjectDto> GetSubjectAsync(Guid? Id)
    {
        if (Id == Guid.Empty || Id is null) return Task.FromResult(new SubjectDto { Id = Id});
        var subject = subjectClient.GetSubject(new SubjectRequest { Id = Id.ToString() });
        return Task.FromResult(new SubjectDto
        {
            Id = Guid.Parse(subject.Id),
            Name = subject.Name
        });
    }

    public Task<LanguageDto> GetLanguageAsync(Guid? Id)
    {
        if (Id == Guid.Empty || Id is null) return Task.FromResult(new LanguageDto { Id = Id });
        var language = languageClient.GetLanguage(new LanguageRequest { Id = Id.ToString() });
        return Task.FromResult(new LanguageDto
        {
            Id = Guid.Parse(language.Id),
            Name = language.Name
        });
    }

    public Task<OwnerDto> GetOwnerAsync(Guid? Id)
    {
        if (Id == Guid.Empty || Id is null) return Task.FromResult(new OwnerDto { Id = Id.ToString() });
        var owner = identityClient.GetIdentity(new IdentityRequest { Id = Id.ToString() });
        return Task.FromResult(new OwnerDto
        {
            Id = owner.Id,
            FullName = owner.Name,
            Image = owner.Image
        });
    }

    public Task<GradeDto> GetGradeAsync(Guid? Id)
    {
        if (Id == Guid.Empty || Id is null) return Task.FromResult(new GradeDto { Id = Id});
        var grade = gradeClient.GetGrade(new GradeRequest { Id = Id.ToString() });
        return Task.FromResult(new GradeDto
        {
            Id = Guid.Parse(grade.Id),
            Name = grade.Name
        });
    }

    public async Task<int> CountQuizAttemptsAsync(Guid? quizId)
    {
        if (quizId == Guid.Empty || quizId is null) return 0;
        var quizResult = await quizResultClient.CountQuizAttemptsAsync(new QuizAttemptsRequest
        {
            Id = quizId.ToString()
        });
        return quizResult.Attempts;
    }
}