using Blazored.SessionStorage;
using ContactApp.Blazor.Core.Authentication;
using ContactApp.Blazor.Dto.Login;
using ContactApp.Blazor.Services.Interface;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using Toolbelt.Blazor;
using Newtonsoft.Json.Linq;

namespace ContactApp.Blazor.Services.Implement;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ISessionStorageService _sessionStorageService;
    private readonly IConfiguration _configuration;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly HttpClientInterceptor _httpClientInterceptor;

    public AuthService(
        HttpClient httpClient, 
        ISessionStorageService sessionStorageService,
        IConfiguration configuration, 
        AuthenticationStateProvider authenticationStateProvider,
        HttpClientInterceptor httpClientInterceptor
         )
    {
        _httpClient = httpClient;
        _sessionStorageService = sessionStorageService;
        _configuration = configuration;
        _authenticationStateProvider = authenticationStateProvider;
        _httpClientInterceptor = httpClientInterceptor;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        LoginResponseDto response = new LoginResponseDto();

        var form = new Dictionary<string, string>
            {
                {"username", request.Username },
                {"password", request.Password },
                {"grant_type", request.GrantType},
                {"client_id", request.ClientId},
                {"client_secret", request.ClientSecret},
                {"scope", request.Scope }
            };

        HttpResponseMessage tokenResponse = await _httpClient.PostAsync("/connect/token", new FormUrlEncodedContent(form));

        var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
        response = JsonConvert.DeserializeObject<LoginResponseDto>(jsonContent);
        response = await AuthenAsync(response, request.Username);
        return response;
    }

    public async Task LogoutAsync()
    {
        await _sessionStorageService.RemoveItemAsync(nameof(LoginResponseDto.access_token));
        await _sessionStorageService.RemoveItemAsync(nameof(LoginResponseDto.refresh_token));
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    #region private mothod

    private async Task<LoginResponseDto> AuthenAsync(LoginResponseDto response, string userName)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(response.access_token);
        var email = jwtSecurityToken?.Claims
                ?.FirstOrDefault(claim => claim.Type == "email")?.Value;
        if (!string.IsNullOrEmpty(userName))
        {
            await _sessionStorageService.SetItemAsync("AccessToken", response.access_token);
            await _sessionStorageService.SetItemAsync("RefreshToken", response.refresh_token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(userName);
        }
        return response;
    }

    #endregion
}
