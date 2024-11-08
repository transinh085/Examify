using Examify.Quiz.Entities;
using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Command.DuplicateQuestion;

public class DuplicateQuestionHandler(IQuestionRepository questionRepository) : IRequestHandler<DuplicateQuestionCommand, IResult>
{
    public async Task<IResult> Handle(DuplicateQuestionCommand request, CancellationToken cancellationToken)
    {
        questionRepository.DuplicateQuestion(request.Id, cancellationToken);
        return TypedResults.Created();
    }
}