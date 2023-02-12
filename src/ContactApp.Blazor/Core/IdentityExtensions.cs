using System.Security.Claims;

namespace ContactApp.Blazor.Core;

public static class IdentityExtensions
{
    public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var claim = ((ClaimsIdentity)claimsPrincipal.Identity)
            .Claims
            .SingleOrDefault(x => x.Type == "sub");
        return claim.Value;
    }

    public static string GetFullName(this ClaimsPrincipal claimsPrincipal)
    {
        var firstName = ((ClaimsIdentity)claimsPrincipal.Identity)
            .Claims
            .SingleOrDefault(x => x.Type == "given_name");

        var lastName = ((ClaimsIdentity)claimsPrincipal.Identity)
            .Claims
            .SingleOrDefault(x => x.Type == "last_name");

        return firstName?.Value + " " + lastName?.Value;
    }
}