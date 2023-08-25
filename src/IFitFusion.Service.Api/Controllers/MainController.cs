using IFitFusion.Service.Api.Auth.Interfaces;
using IFitFusion.Service.Api.Infrastructure.Helpers.DomainHelper.Interface;
using IFitFusion.Service.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace IFitFusion.Service.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class MainController : ControllerBase
    {
        private readonly IDomainNotifier _domainNotifier;
        public readonly IUserLogged AppUser;
        protected int? UserId { get; set; }
        protected bool UserAuthenticated { get; set; }


        public MainController(IDomainNotifier notificador,
                              IUserLogged appUser)
        {
            _domainNotifier = notificador;
            AppUser = appUser;

            if (appUser.IsAuthenticated)
            {
                UserId = appUser.Id;
                UserAuthenticated = true;
            }
        }

        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected IActionResult CustomResponse(object result = null)
        {
            if (ValidOperations())
            {
                return Ok(new ResponseModel<object>
                {
                    ResponseCode = "000",
                    Result = result
                });
            }

            return BadRequest(new ResponseModel<object>
            {
                ResponseCode = HttpStatusCode.Conflict.ToString(),
                ResponseMessage = string.Join(";", _domainNotifier.GetNotifications().Select(n => n.Message)) 
            });
        }

        protected bool ValidOperations()
        {
            return !_domainNotifier.HasNotification();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string errorMsg)
        {
            _domainNotifier.Handle(new DomainNotification(errorMsg));
        }
    }
}
