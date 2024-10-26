using Ardalis.GuardClauses;
using Examify.Catalog.Repositories.Language;
using MediatR;

namespace Examify.Catalog.Features.Languages.UpdateLanguage;

public class UpdateLanguageHandler(ILanguageRepository languageRepository): IRequestHandler<UpdateLanguageCommand, IResult>
{
    public async Task<IResult> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
    {
        var language = await languageRepository.FindLanguageByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, language);
        language.Name = request.Name;
        await languageRepository.UpdateLanguageAsync(language);
        return TypedResults.Ok(language);
    }
}