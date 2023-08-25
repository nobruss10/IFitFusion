using IFitFusion.Service.Api.Auth.Interfaces;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IFitFusion.Service.Api.Auth
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
                new Claim(JwtRegisteredClaimNames.Sid, JsonConvert.SerializeObject(user.Id)),
            };

            return claims;
        }
    }
}
