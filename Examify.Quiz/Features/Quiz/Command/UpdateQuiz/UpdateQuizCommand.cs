using AutoMapper;
using Examify.Quiz.Enums;
using Examify.Quiz.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Command.UpdateQuiz;

public record UpdateQuizCommand : IRequest<IResult>
{
    public Guid Id { get; init; }
    public string Title { get; set; }
    public string? Cover { get; set; }
    public string? Description { get; set; }
    public Guid? SubjectId { get; set; }
    public Guid? GradeId { get; set; }
    public Guid? LanguageId { get; set; }
    public Visibility Visibility { get; set; }
}

public class UpdateQuizValidator : AbstractValidator<UpdateQuizCommand>
{
    public UpdateQuizValidator(QuizContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync((id, cancellationToken) =>
                context.Quizzes.AnyAsync(x => x.Id == id, cancellationToken)
            ).WithMessage("Quiz with this id does not exist");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title can not be longer than 100 characters");

        RuleFor(x => x.Cover)
            .MaximumLength(255).WithMessage("Cover can not be longer than 255 characters");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description can not be longer than 500 characters");

        // RuleFor(x => x.OwnerId)
        //     .NotEmpty().WithMessage("OwnerId is required");

        RuleFor(x => x.Visibility)
            .IsInEnum().WithMessage("Visibility is not valid");
    }
}

// config mapper 
public class UpdateQuizMapper : Profile
{
    public UpdateQuizMapper()
    {
        CreateMap<UpdateQuizCommand, Entities.Quiz>();
    }
}