using IFitFusion.Infrastructure.CrossCutting.DomainHelper.Auth;

namespace IFitFusion.Application.Models.Internal
{
    public class UserIdentityModel : IUserLogged
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
