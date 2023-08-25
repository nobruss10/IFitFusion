using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IFitFusion.Service.Api.Auth
{
    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }

        public static SymmetricSecurityKey GetKey()
        {
            return Create("_Fy@!#19101_00001_0002_0003##123@!@@+__@12");
        }

        public static string GetSubject => "IFitFusion";
        public static string GetIssuer => "IFitFusion.Service";
        public static string GetAudience => "www.IFitFusion.com.br";
    }
}
