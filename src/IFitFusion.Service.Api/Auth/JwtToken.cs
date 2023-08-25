using System.IdentityModel.Tokens.Jwt;

namespace IFitFusion.Service.Api.Auth
{
    public sealed class JwtToken
    {
        public JwtToken(JwtSecurityToken token, int expiresIn)
        {
            ValidTo = token.ValidTo;
            Value = new JwtSecurityTokenHandler().WriteToken(token);
            ExpiresIn = TimeSpan.FromHours(expiresIn).TotalSeconds;
        }

        public DateTime ValidTo { get; private set; }
        public string Value { get; private set; }
        public double ExpiresIn { get; private set; }
    }
}
