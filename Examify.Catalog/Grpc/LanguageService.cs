using Catalog;
using Examify.Catalog.Repositories.Language;
using Grpc.Core;

namespace Examify.Catalog.Grpc
{
    public class LanguageService(ILanguageRepository languageRepository) : Language.LanguageBase
    {
        public override async Task<LanguageReply> GetLanguage(LanguageRequest request, ServerCallContext context)
        {
            var language = await languageRepository.FindLanguageByIdAsync(Guid.Parse(request.Id));
                
            if (language is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Language not found"));
            }
            
            return new LanguageReply
            {
                Id = language?.Id.ToString() ?? string.Empty, 
                Name = language?.Name ?? string.Empty,
            };
        }
    }
}