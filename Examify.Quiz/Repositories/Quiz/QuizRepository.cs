using AutoMapper;
using Examify.Quiz.Dtos;
using Examify.Quiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Quiz;

namespace Examify.Quiz.Repositories.Quiz;

public class QuizRepository : IQuizRepository
{
    private readonly QuizContext _quizContext;
    private readonly Language.LanguageClient _languageClient;
    private readonly Subject.SubjectClient _subjectClient;
    private readonly Grade.GradeClient _gradeClient;
    private readonly IMapper _mapper;

    public QuizRepository(QuizContext quizContext, Language.LanguageClient languageClient, Subject.SubjectClient subjectClient, 
        Grade.GradeClient gradeClient, IMapper mapper)
    {
        _quizContext = quizContext;
        _languageClient = languageClient;
        _subjectClient = subjectClient;
        _gradeClient = gradeClient;
        _mapper = mapper;
    }
    public async Task<Entities.Quiz> CreateQuizEmpty(string userId, CancellationToken cancellationToken)
    {
        var quiz = new Entities.Quiz();
        quiz.OwnerId = Guid.Parse(userId);
        await _quizContext.Quizzes.AddAsync(quiz, cancellationToken);
        await _quizContext.SaveChangesAsync(cancellationToken);
        return quiz;
    }
    
    public async Task DeleteQuizById(Guid id,  CancellationToken cancellationToken)
    {
        var quiz = await _quizContext.Quizzes.FindAsync(id, cancellationToken);
        _quizContext.Quizzes.Remove(quiz);
        await _quizContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<bool> IsQuizExists(Guid id, CancellationToken cancellationToken)
    {
        return await _quizContext.Quizzes.AnyAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task PublishQuiz(Guid id, CancellationToken cancellationToken)
    {
        var quiz = await _quizContext.Quizzes.FindAsync(id, cancellationToken);
        quiz.IsPublished = true;
        await _quizContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task UpdateQuiz(Entities.Quiz quiz, CancellationToken cancellationToken)
    {
        _quizContext.Quizzes.Update(quiz);
        await _quizContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<List<QuizDto>> GetAllQuizzes(CancellationToken cancellationToken)
    {
        var quizzes = await _quizContext.Quizzes.
            Include((quiz) => quiz.Questions).
            AsNoTracking().ToListAsync(cancellationToken);
        var quizDtos = _mapper.Map<List<QuizDto>>(quizzes);
        foreach (var quiz in quizDtos)
        {
            var languageRequest = new LanguageRequest { Id = quiz.LanguageId.ToString() };
            var languageReply = _languageClient.GetLanguage(languageRequest);
            var subjectRequest = new SubjectRequest { Id = quiz.SubjectId.ToString() };
            var subjectReply = _subjectClient.GetSubject(subjectRequest);
            var gradeRequest = new GradeRequest { Id = quiz.GradeId.ToString() };
            var gradeReply = _gradeClient.GetGrade(gradeRequest);
            
            quiz.LanguageName = languageReply.Name;
            quiz.SubjectName = subjectReply.Name;
            quiz.GradeName = gradeReply.Name;
        }
        return quizDtos;
    }

    public async Task<List<QuizDto>> GetQuizByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var quizzes = await _quizContext.Quizzes.AsNoTracking()
            .Where(quiz => quiz.OwnerId == userId)
            .ToListAsync(cancellationToken);
        var quizDtos = _mapper.Map<List<QuizDto>>(quizzes);
        foreach (var quiz in quizDtos)
        {
            var languageRequest = new LanguageRequest { Id = quiz.LanguageId.ToString() };
            var languageReply = _languageClient.GetLanguage(languageRequest);
            var subjectRequest = new SubjectRequest { Id = quiz.SubjectId.ToString() };
            var subjectReply = _subjectClient.GetSubject(subjectRequest);
            quiz.LanguageName = languageReply.Name;
            quiz.SubjectName = subjectReply.Name;
        }
        return quizDtos;
    }
}

