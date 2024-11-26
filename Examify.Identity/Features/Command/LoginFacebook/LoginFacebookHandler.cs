using System.Text.Json;
using Examify.Identity.Entities;
using Examify.Identity.Infrastructure.Identity;
using Examify.Identity.Infrastructure.Jwt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Examify.Identity.Features.Command.LoginFacebook;

public class LoginFacebookHandler(
    IHttpClientFactory httpClientFactory,
    ITokenProvider tokenProvider,
    UserManager<AppUser> userManager,
    ILogger<LoginFacebookHandler> logger,
    IOptions<FacebookOptions> options
)
    : IRequestHandler<LoginFacebookCommand, IResult>
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient();
    private readonly FacebookOptions fbOptions = options.Value;

    public async Task<IResult> Handle(LoginFacebookCommand request, CancellationToken cancellationToken)
    {
        var verifyTokenResponse = await _httpClient.GetAsync(
            $"https://graph.facebook.com/debug_token?input_token={request.AccessToken}&access_token={fbOptions.AppId}|{fbOptions.AppSecret}",
            cancellationToken);

        if (!verifyTokenResponse.IsSuccessStatusCode) throw new UnauthorizedAccessException();

        var fbApiVersion = "v21.0";
        var fbResponse = await _httpClient.GetAsync(
            $"https://graph.facebook.com/{fbApiVersion}/me?fields=id,name,email,picture&access_token={request.AccessToken}",
            cancellationToken);

        if (!fbResponse.IsSuccessStatusCode) throw new UnauthorizedAccessException();

        var fbContent = await fbResponse.Content.ReadAsStringAsync(cancellationToken);
        logger.LogInformation(fbContent);
        var fbUser = JsonSerializer.Deserialize<FacebookUser>(fbContent,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var user = await userManager.FindByEmailAsync(fbUser.Email);

        if (user is null)
        {
            user = new AppUser
            {
                FirstName = fbUser.Name.Split(" ").Take(fbUser.Name.Split(" ").Length - 1)
                    .Aggregate("", (current, name) => current + name + " ").Trim(),
                LastName = fbUser.Name.Split(" ")[
                    fbUser.Name.Split(" ").Length - 1
                ],
                UserName = fbUser.Email,
                Email = fbUser.Email,
                EmailConfirmed = true,
                Image = fbUser.Picture.Data.Url
            };

            var result = await userManager.CreateAsync(user);

            if (!result.Succeeded) throw new UnauthorizedAccessException();
        }

        return TypedResults.Ok(await tokenProvider.AuthenticateAsync(user));
    }
}

public class FacebookUser
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public FacebookPicture Picture { get; set; }
}

public class FacebookPictureData
{
    public int Height { get; set; }
    public bool IsSilhouette { get; set; }
    public string Url { get; set; }
    public int Width { get; set; }
}

public class FacebookPicture
{
    public FacebookPictureData Data { get; set; }
}