namespace IFitFusion.Service.Api.Auth.Interfaces
{
    public interface IUserLogged
    {
        int Id { get; }
        string Name { get; }
        string Email { get; }
        bool IsAuthenticated { get; }
    }
}
