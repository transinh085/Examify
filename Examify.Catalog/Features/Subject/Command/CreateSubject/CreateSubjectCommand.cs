using Examify.Catalog.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Catalog.Features.Subject.Command.CreateSubject;

public record CreateSubjectCommand : IRequest<IResult>
{
    public string Name { get; init; }
}

public class CreateSubjectValidator : AbstractValidator<CreateSubjectCommand>
{
    public CreateSubjectValidator(CatalogContext context)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name is not allowed over 100 characters")
            .MinimumLength(3).WithMessage("Name is not allowed under 3 characters")
            .MustAsync(
                async (name, cancellationToken) =>
                    await context.Subjects.AllAsync(x => x.Name != name, cancellationToken)
            ).WithMessage("The specified name already exists");
    }
}