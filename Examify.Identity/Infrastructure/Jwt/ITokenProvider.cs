﻿using Examify.Identity.Dtos;

namespace Examify.Identity.Infrastructure.Jwt;

public interface ITokenProvider
{
    Task<AuthenticatedDto> AuthenticateAsync(string email, string password);
    Task<AuthenticatedDto> RefreshTokenAsync(string token);
}