using AutoMapper;
using AutoMapper.QueryableExtensions;
using Examify.Core.Pagination;
using Examify.Quiz.Dtos;
using Examify.Quiz.Enums;
using Examify.Quiz.Features.Quiz.Dtos;
using Examify.Quiz.Grpc;
using Examify.Quiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Repositories.Quiz;

public class QuizRepository(
    QuizContext quizContext,
    IQuizMetaService quizMetaService,
    IMapper mapper)
    : IQuizRepository
{
    public async Task<Entities.Quiz> CreateQuizEmpty(string userId, CancellationToken cancellationToken)
    {
        var quiz = new Entities.Quiz
        {
            OwnerId = userId
        };
        await quizContext.Quizzes.AddAsync(quiz, cancellationToken);
        await quizContext.SaveChangesAsync(cancellationToken);
        return quiz;
    }

    public async Task<Entities.Quiz> FindQuizById(Guid id, CancellationToken cancellationToken)
    {
        return await quizContext.Quizzes.FindAsync(id, cancellationToken);
    }

    public async Task DeleteQuizById(Guid id, CancellationToken cancellationToken)
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
        var quizzes = await quizContext.Quizzes.Include((quiz) => quiz.Questions)
            .ThenInclude((question) => question.Options).AsNoTracking().ToListAsync(cancellationToken);
        var quizDtos = mapper.Map<List<QuizDto>>(quizzes);
        foreach (var quiz in quizDtos)
        {
            var languageReply = await quizMetaService.GetLanguageAsync(quiz.LanguageId);
            var subjectReply = await quizMetaService.GetSubjectAsync(quiz.SubjectId);
            var gradeReply = await quizMetaService.GetGradeAsync(quiz.GradeId);
            var identityReply = await quizMetaService.GetOwnerAsync(quiz.OwnerId);

            quiz.LanguageName = languageReply.Name;
            quiz.SubjectName = subjectReply.Name;
            quiz.GradeName = gradeReply.Name;

            quiz.Owner = new QuizDto.OwnerDto
            {
                Id = identityReply.Id,
                Name = identityReply.FullName,
                Image = identityReply.Image
            };
        }

        return quizDtos;
    }

    public async Task<QuizUserDto> GetQuizByUserId(string userId, CancellationToken cancellationToken)
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
                var languageTask = quizMetaService.GetLanguageAsync(quiz.LanguageId);
                var subjectTask = quizMetaService.GetSubjectAsync(quiz.SubjectId);
                var gradeTask = quizMetaService.GetGradeAsync(quiz.GradeId);
                var identityTask = quizMetaService.GetOwnerAsync(quiz.OwnerId);

                await Task.WhenAll(languageTask, subjectTask, gradeTask, identityTask);

                quiz.LanguageName = (await languageTask).Name;
                quiz.SubjectName = (await subjectTask).Name;
                quiz.GradeName = (await gradeTask).Name;
                var identityReply = await identityTask;
                quiz.Owner = new QuizDto.OwnerDto
                {
                    Id = identityReply.Id,
                    Name = identityReply.FullName,
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

    public async Task<PopulatedQuizDto?> GetQuizById(string quizId)
    {
        var quiz = await quizContext.Quizzes
            .Include(quiz => quiz.Questions)
            .ThenInclude(question => question.Options)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == Guid.Parse(quizId));

        return mapper.Map<PopulatedQuizDto>(quiz);
    }
    
    public async Task<PopulatedQuizDto?> GetQuizByCode(string code)
    {
        var quiz = await quizContext.Quizzes
            .Include(quiz => quiz.Questions)
            .ThenInclude(question => question.Options)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Code == code);

        return mapper.Map<PopulatedQuizDto>(quiz);
    }

    public async Task<PagedList<QuizItemResponseDto>> SearchQuizzes(string? keyword, Guid? subjectId, int pageNumber,
        int pageSize,
        CancellationToken cancellationToken)
    {
        var query = quizContext.Quizzes.AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(q => q.Title.ToLower().Contains(keyword.ToLower()));
        }

        if (subjectId.HasValue)
        {
            query = query.Where(q => q.SubjectId == subjectId.Value);
        }

        query = query.Where(q => q.IsPublished && q.Visibility == Visibility.Public)
            .AsNoTracking();

        var quizzes = await query
            .ProjectTo<QuizItemResponseDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(pageNumber, pageSize);

        await PopulateQuizDetailsAsync(quizzes);

        return quizzes;
    }

    private async Task PopulateQuizDetailsAsync(PagedList<QuizItemResponseDto> quizDtos)
    {
        foreach (var quiz in quizDtos.Items)
        {
            quiz.Language = await quizMetaService.GetLanguageAsync(quiz.Language.Id);
            quiz.Subject = await quizMetaService.GetSubjectAsync(quiz.Subject.Id);
            quiz.Grade = await quizMetaService.GetGradeAsync(quiz.Grade.Id);
            quiz.Owner = await quizMetaService.GetOwnerAsync(Guid.Parse(quiz.Owner.Id));
            quiz.AttemptCount = await quizMetaService.CountQuizAttemptsAsync(quiz.Id);
        }
    }

    public async Task PlayQuiz(Guid id, CancellationToken cancellationToken)
    {
        var quiz = await quizContext.Quizzes.FindAsync(id, cancellationToken);
        Random random = new();
        quiz.Code = random.Next(100000, 999999).ToString();
        quiz.PlayTime = DateTime.UtcNow;
        quizContext.Quizzes.Update(quiz);
        await quizContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task EndQuiz(Guid id, CancellationToken cancellationToken)
    {
        var quiz = await quizContext.Quizzes.FindAsync(id, cancellationToken);
        quiz.Code = null;
        quiz.IsStart = false;
        quiz.PlayTime = null;
        quizContext.Quizzes.Update(quiz);
        await quizContext.SaveChangesAsync(cancellationToken);
    }

    public async Task StartQuiz(Guid id, CancellationToken cancellationToken)
    {
        var quiz = await quizContext.Quizzes.FindAsync(id, cancellationToken);
        quiz.IsStart = true;
        quizContext.Quizzes.Update(quiz);
        await quizContext.SaveChangesAsync(cancellationToken);
    }
}