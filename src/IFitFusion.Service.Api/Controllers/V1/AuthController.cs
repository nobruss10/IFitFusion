using IFitFusion.Service.Api.ApplicationInterfaces;
using IFitFusion.Service.Api.ApplicationModels.Request;
using IFitFusion.Service.Api.Auth.Interfaces;
using IFitFusion.Service.Api.Infrastructure.Helpers.DomainHelper.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IFitFusion.Service.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : MainController
    {
        private IUserAppService _userAppService;
        public AuthController(
            IDomainNotifier notificador,
            IUserLogged appUser,
            IUserAppService userAppService) 
            : base(notificador, appUser)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRequestModel request)
        {
            if (!ModelState.IsValid) 
                return CustomResponse(ModelState);

            await _userAppService.Register(request);
            return CustomResponse();
        }

        [HttpPost]
        [Route("Token")]
        [AllowAnonymous]
        public async Task<IActionResult> Token([FromBody] LoginRequestModel request)
        {
            var token =  await _userAppService.Login(request);

            return CustomResponse(token);
        }
    }
}
