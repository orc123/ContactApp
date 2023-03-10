using Newtonsoft.Json;

namespace ContactApp.Blazor.Dto.Login;

public class LoginRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string GrantType { get; set; }
    public string Scope { get; set; }
}
