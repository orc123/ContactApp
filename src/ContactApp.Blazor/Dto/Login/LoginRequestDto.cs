using Newtonsoft.Json;

namespace ContactApp.Blazor.Dto.Login;

public class LoginRequestDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    [JsonProperty("client_id")]
    public string? ClientId { get; set; }
    [JsonProperty("grant_type")]
    public string? GrantType { get; set; }
    public string? Scope { get; set; }
}
