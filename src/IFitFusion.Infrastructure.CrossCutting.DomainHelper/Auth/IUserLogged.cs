namespace IFitFusion.Infrastructure.CrossCutting.DomainHelper.Auth
{
    public interface IUserLogged
    {
        int Id { get; }
        string Name { get; }
        string Email { get; }
        bool IsAuthenticated { get; }
    }
}
