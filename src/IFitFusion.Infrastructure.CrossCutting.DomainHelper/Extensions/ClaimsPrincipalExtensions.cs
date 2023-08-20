using System.Security.Claims;

namespace IFitFusion.Service.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));
            
            var claim = principal.FindFirst(x => x.Type == "Id");
            return claim?.Value!;
        }   

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));
            
            var claim = principal.FindFirst(x => x.Type == "Email"); 
            return claim?.Value!;
        }
    }
}
