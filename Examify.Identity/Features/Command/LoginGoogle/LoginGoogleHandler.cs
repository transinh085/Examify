using System.Text.Json;
using Examify.Identity.Entities;
using Examify.Identity.Infrastructure.Identity;
using Examify.Identity.Infrastructure.Jwt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Examify.Identity.Features.Command.LoginGoogle;

public class LoginGoogleHandler(
    IHttpClientFactory httpClientFactory,
    ITokenProvider tokenProvider,
    UserManager<AppUser> userManager,
    ILogger<LoginGoogleHandler> logger,
    IOptions<GoogleOptions> options
) : IRequestHandler<LoginGoogleCommand, IResult>
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient();
    private readonly GoogleOptions googleOptions = options.Value;

    public async Task<IResult> Handle(LoginGoogleCommand request, CancellationToken cancellationToken)
    {
        var verifyUrl = $"https://www.googleapis.com/oauth2/v3/userinfo?access_token={request.AccessToken}";
        var verifyTokenResponse = await _httpClient.GetAsync(verifyUrl, cancellationToken);

        if (!verifyTokenResponse.IsSuccessStatusCode)
        {
            throw new UnauthorizedAccessException("Invalid token");
        }

        logger.LogInformation(
            $"Google token verification response: {await verifyTokenResponse.Content.ReadAsStringAsync(cancellationToken)}");


        // var googleUser = JsonSerializer.Deserialize<GoogleUser>(
        //     await verifyTokenResponse.Content.ReadAsStringAsync(cancellationToken),
        //     new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return TypedResults.Ok();
    }
}

public class GoogleUser
{
    public string Sub { get; set; }
    public string Name { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public string Picture { get; set; }
    public string Email { get; set; }
    public bool EmailVerified { get; set; }
}