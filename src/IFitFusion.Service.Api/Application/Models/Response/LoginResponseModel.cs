using IFitFusion.Service.Api.ApplicationModels.Request;

namespace IFitFusion.Service.Api.ApplicationModels.Response
{
    public class LoginResponseModel
    {
        public string? AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenResponseModel? UserToken { get; set; }
    }
}
