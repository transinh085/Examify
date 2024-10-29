using Examify.Catalog.Infrastructure.Data;
using Examify.Catalog.Repositories.Language;
using FluentValidation;
using MediatR;

namespace Examify.Catalog.Features.Languages.CreateLanguage;

public record CreateLanguageCommand(string Name) : IRequest<IResult>;

public class CreatelanguageValidator : AbstractValidator<CreateLanguageCommand>
{
    private readonly ILanguageRepository _languageRepository;
    
    public CreatelanguageValidator(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name is not allowed over 100 characters")
            .MinimumLength(2).WithMessage("Name is not allowed under 2 characters");
    }
}