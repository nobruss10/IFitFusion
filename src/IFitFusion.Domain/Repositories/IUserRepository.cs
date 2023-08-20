using IFitFusion.Domain.Entities;

namespace IFitFusion.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User> PasswordSignInAsync(string email, string Password);
        Task<bool> CheckEmail(string email);
        public Task AddUser(User user);
    }
}
