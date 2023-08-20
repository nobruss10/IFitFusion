using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Exceptions;
using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Models;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using System.Security.Authentication;

namespace Pricefy.BackLib.AspnetCore.Middlewares
{
    public class RequestHandlerMiddleware
    {
        public RequestHandlerMiddleware() { }

        public async Task InvokeAsync(HttpContext context)
        {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

            if (contextFeature is not null && contextFeature.Error is not null)
            {
                context.Response.StatusCode = (int)GetErrorCode(contextFeature.Error);
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel<object>()
                {
                    ResponseCode = GetResponseCode(contextFeature.Error),
                    ResponseMessage = contextFeature.Error.Message
                }));
            }
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            return e switch
            {
                ApplicationException or AppException => HttpStatusCode.BadRequest,
                AuthenticationException => HttpStatusCode.Forbidden,
                _ => HttpStatusCode.InternalServerError
            };
        }

        private static string GetResponseCode(Exception e)
        {
            if (e is not null and AppException)
                return (e as AppException).Code.ToString();

            return "999";
        }
    }
}
