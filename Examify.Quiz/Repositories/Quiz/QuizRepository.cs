using AutoMapper;
using Examify.Core.Pagination;
using Examify.Quiz.Dtos;
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

    public async Task<PagedList<QuizUserDto>> GetAllQuizzes(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        PagedList<Entities.Quiz> quizzes = await quizContext.Quizzes
            .Include(quiz => quiz.Questions)
            .ThenInclude(question => question.Options)
            .AsNoTracking()
            .PaginatedListAsync(pageNumber, pageSize);
        var quizDtos = new List<QuizUserDto>();
        foreach (var quiz in quizzes.Items)
        {
            quizDtos.Add(new QuizUserDto
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Description = quiz.Description,
                Cover = quiz.Cover,
                Duration = quiz.Questions.Sum(q => q.Duration),
                NumberQuestions = quiz.Questions.Count,
                IsPublished = quiz.IsPublished,
                Language = quiz.LanguageId.HasValue
                    ? await GetLanguageAsync(quiz.LanguageId.Value, cancellationToken)
                    : null,
                Subject = quiz.SubjectId.HasValue
                    ? await GetSubjectAsync(quiz.SubjectId.Value, cancellationToken)
                    : null,
                Grade = quiz.GradeId.HasValue
                    ? await GetGradeAsync(quiz.GradeId.Value, cancellationToken)
                    : null,
                Owner = quiz.OwnerId.HasValue 
                    ? await GetOwnerAsync(quiz.OwnerId.Value, cancellationToken)
                    : null,
            });
        }

        return new PagedList<QuizUserDto>(items: quizDtos, count: quizzes.Meta.TotalCount, pageNumber: quizzes.Meta.TotalPages, pageSize: quizzes.Meta.PageSize);
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

    public Task<List<PopulatedQuizDto>> GetQuizzesBySubject(Guid subjectId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList<QuizUserDto>> GetQuizPublishedByUserId(Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        PagedList<Entities.Quiz> quizzes = await quizContext.Quizzes
            .Where(quiz => quiz.OwnerId == userId && quiz.IsPublished)
            .Include(quiz => quiz.Questions)
            .ThenInclude(question => question.Options)
            .AsNoTracking()
            .PaginatedListAsync(pageNumber, pageSize);
        var quizDtos = new List<QuizUserDto>();
        foreach (var quiz in quizzes.Items)
        {
            quizDtos.Add(new QuizUserDto
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Description = quiz.Description,
                Cover = quiz.Cover,
                Duration = quiz.Questions.Sum(q => q.Duration),
                NumberQuestions = quiz.Questions.Count,
                IsPublished = quiz.IsPublished,
                Language = quiz.LanguageId.HasValue
                    ? await GetLanguageAsync(quiz.LanguageId.Value, cancellationToken)
                    : null,
                Subject = quiz.SubjectId.HasValue
                    ? await GetSubjectAsync(quiz.SubjectId.Value, cancellationToken)
                    : null,
                Grade = quiz.GradeId.HasValue
                    ? await GetGradeAsync(quiz.GradeId.Value, cancellationToken)
                    : null,
                Owner = quiz.OwnerId.HasValue 
                    ? await GetOwnerAsync(quiz.OwnerId.Value, cancellationToken)
                    : null,
            });
        }

        return new PagedList<QuizUserDto>(items: quizDtos, count: quizzes.Meta.TotalCount, pageNumber: quizzes.Meta.TotalPages, pageSize: quizzes.Meta.PageSize);
    }
    
    private async Task<QuizUserDto.LanguageDto?> GetLanguageAsync(Guid languageId, CancellationToken cancellationToken)
    {
        var request = new LanguageRequest { Id = languageId.ToString() };
        var response = await languageClient.GetLanguageAsync(request, cancellationToken: cancellationToken);

        return response.ResponseCase switch
        {
            GetLanguageResponse.ResponseOneofCase.Language => new QuizUserDto.LanguageDto
            {
                Id = Guid.Parse(response.Language.Id),
                Name = response.Language.Name
            },
            _ => null
        };
    }
    
    private async Task<QuizUserDto.SubjectDto?> GetSubjectAsync(Guid subjectId, CancellationToken cancellationToken)
    {
        var request = new SubjectRequest { Id = subjectId.ToString() };
        var response = await subjectClient.GetSubjectAsync(request, cancellationToken: cancellationToken);

        return response.ResponseCase switch
        {
            GetSubjectResponse.ResponseOneofCase.Subject => new QuizUserDto.SubjectDto
            {
                Id = Guid.Parse(response.Subject.Id),
                Name = response.Subject.Name
            },
            _ => null
        };
    }
    
    private async Task<QuizUserDto.GradeDto?> GetGradeAsync(Guid gradeId, CancellationToken cancellationToken)
    {
        var request = new GradeRequest { Id = gradeId.ToString() };
        var response = await gradeClient.GetGradeAsync(request, cancellationToken: cancellationToken);

        return response.ResponseCase switch
        {
            GetGradeResponse.ResponseOneofCase.Grade => new QuizUserDto.GradeDto
            {
                Id = Guid.Parse(response.Grade.Id),
                Name = response.Grade.Name
            },
            _ => null
        };
    }
    
    private async Task<QuizUserDto.OwnerDto?> GetOwnerAsync(Guid ownerId, CancellationToken cancellationToken)
    {
        var request = new IdentityRequest { Id = ownerId.ToString() };
        var response = await identityClient.GetIdentityAsync(request, cancellationToken: cancellationToken);
        
        return response.ResponseCase switch
        {
            GetIdentityResponse.ResponseOneofCase.Identity => new QuizUserDto.OwnerDto
            {
                Id = response.Identity.Id,
                Name = response.Identity.Name,
                Image = response.Identity.Image
            },
            _ => null
        };
    }
}