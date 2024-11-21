﻿using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Result.Command.CreateQuizResult;

public record CreateQuizResultCommand : IRequest<IResult>
{
    public string QuizId { get; init; }
    
    public string UserId { get; init; }
    
}

public class CreateQuizResultValidator : AbstractValidator<CreateQuizResultCommand>
{
    public CreateQuizResultValidator()
    {
        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("QuizId is required");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required");
    }
}
