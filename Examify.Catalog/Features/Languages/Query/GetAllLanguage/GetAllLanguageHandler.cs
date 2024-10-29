using Examify.Catalog.Repositories.Language;
using MediatR;

namespace Examify.Catalog.Features.Languages.GetAllLanguage;

public class GetAllLanguageHandler(ILanguageRepository languageRepository) : IRequestHandler<GetAllLanguageQuery, IResult>
{
    public async Task<IResult> Handle(GetAllLanguageQuery request, CancellationToken cancellationToken)
    {
        var languages = await languageRepository.GetLanguagesAsync(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize
        );
        
        return TypedResults.Ok(languages);
    }
}
