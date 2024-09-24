using Microsoft.Extensions.Options;

namespace Examify.Infrastructure.Options;

public class AppOptions : IOptionsRoot
{
    public string Name { get; set; }
}