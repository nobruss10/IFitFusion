using IFitFusion.Application.Models;
using IFitFusion.Application.Models.Request;
using IFitFusion.Application.Models.Response;

namespace IFitFusion.Application.Interfaces
{
    public interface IUserAppService
    {
        Task Register(UserRequestModel userModel);
        Task<LoginResponseModel> Login(LoginRequestModel loginRequest);
    }
}
