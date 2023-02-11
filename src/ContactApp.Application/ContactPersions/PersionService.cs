using Microsoft.AspNetCore.Authorization;

namespace ContactApp;

[Authorize]
public class PersionService : IPersionService
{
}
