using Examify.Quiz.Repositories.Quiz;
using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.StartQuiz;

public record StartQuizCommand(Guid QuizId) : IRequest<IResult>;

public class StartQuizValidator : AbstractValidator<StartQuizCommand>
{
    public StartQuizValidator(IQuizRepository quizRepository)
    {
        RuleFor(x => x.QuizId).NotEmpty()
            .WithMessage("Quiz Id is required.")
            .MustAsync(async (id, cancellation) =>
                await quizRepository.IsQuizExists(id, cancellation)
            ).WithMessage("Quiz not found.");
    }
}