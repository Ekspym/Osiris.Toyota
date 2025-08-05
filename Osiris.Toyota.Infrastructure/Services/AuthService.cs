using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Entities;
using Osiris.Toyota.Core.Enums;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public interface IAuthService
{
    Task<string> GetAccessTokenAsync(ExternalSystem system);
    Task RefreshTokenAsync(ExternalSystem system);
}

public class AuthService : IAuthService
{
    private readonly IAuthStrategy _authStrategy;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IAuthStrategy authStrategy, ILogger<AuthService> logger)
    {
        _authStrategy = authStrategy;
        _logger = logger;
    }

    public async Task<string> GetAccessTokenAsync(ExternalSystem system)
    {
        var request = new HttpRequestMessage();
        var result = await _authStrategy.ApplyAuthorizationAsync(request, system);
        return result.IsSuccess ? request.Headers.Authorization.Parameter : null;
    }

    public async Task RefreshTokenAsync(ExternalSystem system)
    {
        // Implementation specific to Toyotas OAuth2 
    }
}