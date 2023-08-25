using IFitFusion.Service.Api.Auth.Interfaces;
using IFitFusion.Service.Api.Extensions;

namespace IFitFusion.Service.Api.Auth
{
    public class UserLogged : IUserLogged
    {
        private readonly IHttpContextAccessor _accessor;

        public UserLogged(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor?.HttpContext?.User?.Identity?.Name ?? string.Empty;
        public int Id => IsAuthenticated ? Convert.ToInt32(_accessor?.HttpContext?.User.GetUserId()) : 0;
        public string Email => _accessor?.HttpContext?.User.GetUserEmail() ?? string.Empty;
        public bool IsAuthenticated => _accessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    }
}
