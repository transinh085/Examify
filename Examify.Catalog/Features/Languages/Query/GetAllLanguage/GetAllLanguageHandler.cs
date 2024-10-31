using Examify.Catalog.Repositories.Language;
using MediatR;

namespace Examify.Catalog.Features.Languages.GetAllLanguage;

public class GetAllLanguageHandler(ILanguageRepository languageRepository) : IRequestHandler<GetAllLanguageQuery, IResult>
{
    public async Task<IResult> Handle(GetAllLanguageQuery request, CancellationToken cancellationToken)
    {
        var languages = await languageRepository.GetLanguagesAsync();
        
        return TypedResults.Ok(languages);
    }
}
