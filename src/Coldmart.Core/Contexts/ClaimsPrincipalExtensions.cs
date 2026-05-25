using System.Security.Claims;

namespace Coldmart.Core.Contexts
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst("JWT");
            return claim?.Value;
        }
    }
}
