using Dapper;
using IFitFusion.Service.Api.Domain.Repositories;
using IFitFusion.Service.Api.Domain.Entities;
using IFitFusion.Service.Api.Infrastructure.Data.Queries;
using System.Data;

namespace IFitFusion.Service.Api.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public async Task<User> PasswordSignInAsync(string email, string password)
        {
            return await QueryFirstOrDefaultAsync<User>(UserQuery.PasswordSign, new { email, password });
        }

        public async Task<bool> CheckEmail(string email)
        {
            return (await ExecuteScalarAsync(UserQuery.CheckEmail, new { email })) > 0;
        }

        public async Task AddUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", user.Name, DbType.String);
            parameters.Add("@BirthDate", user.BirthDate, DbType.Date);
            parameters.Add("@Gender", user.Gender.ToString(), DbType.String);
            parameters.Add("@Email", user.Email.Adreess, DbType.String);
            parameters.Add("@Password", user.Password.PasswordStr, DbType.String);
            parameters.Add("@Active", user.Active, DbType.Boolean);
            parameters.Add("@Phone", user.Phone, DbType.String);
            parameters.Add("@Height", user.Height, DbType.Decimal);
            parameters.Add("@Weight", user.Weight, DbType.Decimal);
            parameters.Add("@Goal", user.Goal, DbType.String);


            await ExecuteAsync(UserQuery.Insert, parameters);
        }
    }
}
