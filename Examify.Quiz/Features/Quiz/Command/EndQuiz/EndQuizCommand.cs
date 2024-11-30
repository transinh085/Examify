using Examify.Quiz.Repositories.Quiz;
using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.EndQuiz;

public record EndQuizCommand(Guid QuizId) : IRequest<IResult>;

public class GetQuizValidator : AbstractValidator<EndQuizCommand>
{
    public GetQuizValidator(IQuizRepository quizRepository)
    {
        RuleFor(x => x.QuizId).NotEmpty()
            .WithMessage("Quiz Id is required.")
            .MustAsync(async (id, cancellation) =>
                await quizRepository.IsQuizExists(id, cancellation)
            ).WithMessage("Quiz not found.");
    }
}