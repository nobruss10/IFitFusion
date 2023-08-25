using IFitFusion.Service.Api.Domain.Entities;

namespace IFitFusion.Service.Api.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User> PasswordSignInAsync(string email, string Password);
        Task<bool> CheckEmail(string email);
        public Task AddUser(User user);
    }
}
