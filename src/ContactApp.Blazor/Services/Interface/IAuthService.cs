using ContactApp.Blazor.Dto.Login;

namespace ContactApp.Blazor.Services.Interface;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
}
