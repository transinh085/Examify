using AutoMapper;
using Examify.Quiz.Entities;
using Examify.Quiz.Features.Quiz.Dtos;
using Examify.Quiz.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Query.GetQuestionsByQuizId;

public class GetQuestionsByQuizIdHandler(QuizContext context, IMapper mapper)
    : IRequestHandler<GetQuesionsByQuizIdQuery, IResult>
{
    public async Task<IResult> Handle(GetQuesionsByQuizIdQuery request, CancellationToken cancellationToken)
    {
        var questions = await context.Questions.Include(e => e.Options)
            .AsNoTracking()
            .Where(e => e.QuizId == request.Id)
            .ToListAsync<Question>(cancellationToken);
        var questionsDto = mapper.Map<List<QuizDto.QuestionDto>>(questions);
        return TypedResults.Ok(questionsDto);
    }
}