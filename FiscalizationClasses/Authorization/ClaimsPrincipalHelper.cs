using System.Security.Claims;
namespace Fiscalizator.FiscalizationClasses.Authorization
{
    public static class ClaimsPrincipalHelper
    {
        public static int? GetClientId(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                return null;
            }
            Claim clientIdClaim = user.Claims.FirstOrDefault(c => c.Type == "clientId")!;
            if (clientIdClaim != null && int.TryParse(clientIdClaim.Value, out int clientId))
            {
                return clientId;
            }
            throw new InvalidOperationException("ClientId claim is missing or invalid.");
        }
    }
}
