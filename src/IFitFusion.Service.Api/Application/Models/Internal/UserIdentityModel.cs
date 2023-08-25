using IFitFusion.Service.Api.Auth.Interfaces;

namespace IFitFusion.Service.Api.ApplicationModels.Internal
{
    public class UserIdentityModel : IUserLogged
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
