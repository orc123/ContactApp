using ContactApp.Blazor.Dto.Login;
using ContactApp.Blazor.Services.Interface;

namespace ContactApp.Blazor.Services.Implement;

public class AuthService : IAuthService
{
    private readonly HttpClient 
        _httpClient;
    private readonly IConfiguration _configuration;

    public AuthService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        return new LoginResponseDto();
    }
}
