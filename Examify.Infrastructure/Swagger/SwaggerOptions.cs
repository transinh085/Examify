using Examify.Infrastructure.Options;

namespace Examify.Infrastructure.Swagger;

public class SwaggerOptions : IOptionsRoot
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}