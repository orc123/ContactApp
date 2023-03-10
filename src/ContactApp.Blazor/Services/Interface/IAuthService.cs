using ContactApp.Blazor.Dto.Login;

namespace ContactApp.Blazor.Services.Interface;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    Task LogoutAsync();
    //void RegisterEvent();
    //void DisposeEvent();
}
