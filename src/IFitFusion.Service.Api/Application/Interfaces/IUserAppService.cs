using IFitFusion.Service.Api.ApplicationModels;
using IFitFusion.Service.Api.ApplicationModels.Request;
using IFitFusion.Service.Api.ApplicationModels.Response;

namespace IFitFusion.Service.Api.ApplicationInterfaces
{
    public interface IUserAppService
    {
        Task Register(UserRequestModel userModel);
        Task<LoginResponseModel> Login(LoginRequestModel loginRequest);
    }
}
