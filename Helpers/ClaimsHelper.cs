using System.Security.Claims;

namespace Fiscalizator.Helpers
{
    public static class ClaimsHelper
    {
        public static string GetRole(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
        }
        public static string GetClientId(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == "clientId").Value;
        }
    }
}
