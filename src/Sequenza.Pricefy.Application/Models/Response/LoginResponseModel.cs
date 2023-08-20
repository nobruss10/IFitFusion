using IFitFusion.Application.Models.Request;

namespace IFitFusion.Application.Models.Response
{
    public class LoginResponseModel
    {
        public string? AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenResponseModel? UserToken { get; set; }
    }
}
