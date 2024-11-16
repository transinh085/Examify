using AutoMapper;
using Examify.Quiz.Features.Quiz.Dtos;
using Examify.Quiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Quiz;

namespace Examify.Quiz.Repositories.Quiz;

public class QuizRepository(
    QuizContext quizContext,
    Language.LanguageClient languageClient,
    Subject.SubjectClient subjectClient,
    Grade.GradeClient gradeClient,
    Identity.IdentityClient identityClient,
    IMapper mapper)
    : IQuizRepository
{
    public async Task<Entities.Quiz> CreateQuizEmpty(string userId, CancellationToken cancellationToken)
    {
        var quiz = new Entities.Quiz();
        quiz.OwnerId = Guid.Parse(userId);
        await quizContext.Quizzes.AddAsync(quiz, cancellationToken);
        await quizContext.SaveChangesAsync(cancellationToken);
        return quiz;
    }
    
    public async Task<Entities.Quiz> FindQuizById(Guid id, CancellationToken cancellationToken)
    {
        return await quizContext.Quizzes.FindAsync(id, cancellationToken);
    }
    
    public async Task DeleteQuizById(Guid id,  CancellationToken cancellationToken)
    {
        var quiz = await quizContext.Quizzes.FindAsync(id, cancellationToken);
        quizContext.Quizzes.Remove(quiz);
        await quizContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<bool> IsQuizExists(Guid id, CancellationToken cancellationToken)
    {
        return await quizContext.Quizzes.AnyAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task PublishQuiz(Guid id, CancellationToken cancellationToken)
    {
        var quiz = await quizContext.Quizzes.FindAsync(id, cancellationToken);
        quiz.IsPublished = true;
        await quizContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task UpdateQuiz(Entities.Quiz quiz, CancellationToken cancellationToken)
    {
        quizContext.Quizzes.Update(quiz);
        await quizContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<List<QuizDto>> GetAllQuizzes(CancellationToken cancellationToken)
    {
        var quizzes = await quizContext.Quizzes.
            Include((quiz) => quiz.Questions).
            ThenInclude((question) => question.Options).
            AsNoTracking().ToListAsync(cancellationToken);
        var quizDtos = mapper.Map<List<QuizDto>>(quizzes);
        foreach (var quiz in quizDtos)
        {
            var languageRequest = new LanguageRequest { Id = quiz.LanguageId.ToString() };
            var languageReply = languageClient.GetLanguage(languageRequest);
            var subjectRequest = new SubjectRequest { Id = quiz.SubjectId.ToString() };
            var subjectReply = subjectClient.GetSubject(subjectRequest);
            var gradeRequest = new GradeRequest { Id = quiz.GradeId.ToString() };
            var gradeReply = gradeClient.GetGrade(gradeRequest);
            var indentityRequest = new IdentityRequest { Id = quiz.OwnerId.ToString() };
            var identityReply = identityClient.GetIdentity(indentityRequest);
            
            quiz.LanguageName = languageReply.Name;
            quiz.SubjectName = subjectReply.Name;
            quiz.GradeName = gradeReply.Name;
            
            quiz.Owner = new QuizDto.OwnerDto
            {
                Id = identityReply.Id,
                Name = identityReply.Name,
                Image = identityReply.Image
            };
        }
        return quizDtos;
    }
    
    public async Task<QuizUserDto> GetQuizByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var quizzes = await quizContext.Quizzes
            .Where(quiz => quiz.OwnerId == userId)
            .Include(quiz => quiz.Questions)
                .ThenInclude(question => question.Options)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var publishedQuizzes = quizzes.Where(q => q.IsPublished).ToList();
        var unpublishedQuizzes = quizzes.Where(q => !q.IsPublished).ToList();

        var quizPublishedDtos = mapper.Map<List<QuizDto>>(publishedQuizzes);
        var quizUnpublishedDtos = mapper.Map<List<QuizDto>>(unpublishedQuizzes);

        async Task PopulateQuizDetailsAsync(List<QuizDto> quizDtos)
        {
            var tasks = quizDtos.Select(async quiz =>
            {
                var languageTask = languageClient.GetLanguageAsync(new LanguageRequest { Id = quiz.LanguageId.ToString() }).ResponseAsync;
                var subjectTask = subjectClient.GetSubjectAsync(new SubjectRequest { Id = quiz.SubjectId.ToString() }).ResponseAsync;
                var gradeTask = gradeClient.GetGradeAsync(new GradeRequest { Id = quiz.GradeId.ToString() }).ResponseAsync;
                var identityTask = identityClient.GetIdentityAsync(new IdentityRequest { Id = quiz.OwnerId.ToString() }).ResponseAsync;

                await Task.WhenAll(languageTask, subjectTask, gradeTask, identityTask);

                quiz.LanguageName = (await languageTask).Name;
                quiz.SubjectName = (await subjectTask).Name;
                quiz.GradeName = (await gradeTask).Name;
                var identityReply = await identityTask;
                quiz.Owner = new QuizDto.OwnerDto
                {
                    Id = identityReply.Id,
                    Name = identityReply.Name,
                    Image = identityReply.Image
                };
            });

            await Task.WhenAll(tasks);
        }

        await Task.WhenAll(
            PopulateQuizDetailsAsync(quizPublishedDtos),
            PopulateQuizDetailsAsync(quizUnpublishedDtos)
        );

        return new QuizUserDto
        {
            quizPulished = quizPublishedDtos,
            quizUnpublished = quizUnpublishedDtos
        };
    }

}

