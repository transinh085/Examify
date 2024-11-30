using Examify.Quiz.Repositories.Quiz;
using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.PlayQuiz;

public record PlayQuizCommand(Guid QuizId) : IRequest<IResult>;

public class GetQuizValidator : AbstractValidator<PlayQuizCommand>
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