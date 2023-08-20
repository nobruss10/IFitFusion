using IFitFusion.Infrastructure.CrossCutting.Helpers.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IFitFusion.Infrastructure.CrossCutting.DomainHelper.Auth
{
    public class AuthService
    {
        public JwtToken GenerateToken(IUserLogged user)
        {
            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.GetKey())
                                .AddSubject(JwtSecurityKey.GetSubject)
                                .AddIssuer(JwtSecurityKey.GetIssuer)
                                .AddAudience(JwtSecurityKey.GetAudience)
                                .AddClaims(BuildClaims(user))
                                .AddExpiry(2280)
                                .Build();

            return token;
        }

        private List<Claim> BuildClaims(IUserLogged user)
        {
            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()!),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Name),
                new Claim(JwtRegisteredClaimNames.Actort, user.Name),
                new Claim("Email", user.Email),
                new Claim(JwtRegisteredClaimNames.Sid, JConvert.SerializeObject(user.Id)),
            };

            return claims;
        }
    }
}
