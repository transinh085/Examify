using Catalog;
using Examify.Catalog.Repositories.Language;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Examify.Catalog.Grpc
{
    public class LanguageService(ILanguageRepository languageRepository) : Language.LanguageBase
    {
        public override async Task<GetLanguageResponse> GetLanguage(LanguageRequest request, ServerCallContext context)
        {
            var language = await languageRepository.FindLanguageByIdAsync(Guid.Parse(request.Id));

            if (language is null)
            {
                return new GetLanguageResponse
                {
                    Empty = new Empty()
                };
            }
            return new GetLanguageResponse
            {
                Language = new LanguageReply
                {
                    Id = language.Id.ToString(),
                    Name = language.Name,
                }
            };
        }
    }
}