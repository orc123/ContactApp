using Newtonsoft.Json;

namespace ContactApp.Blazor.Dto.Login;

public class LoginResponseDto
{
    [JsonProperty("access_token")]
    public string access_token { get; set; }

    [JsonProperty("token_type")]
    public string token_type { get; set; }

    [JsonProperty("expires_in")]
    public int expires_in { get; set; }

    [JsonProperty("refresh_token")]
    public string refresh_token { get; set; }

    [JsonProperty("id_token")]
    public string id_token { get; set; }

}
