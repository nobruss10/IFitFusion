using Dapper;
using IFitFusion.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FitFusion.Infrastructure.Data.Repositories
{

    public abstract class BaseRepository
    {
        private readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnection")!;
        }

        public async Task<int> ExecuteAsync(string sqlCommand, DynamicParameters parameters = null)
        {
            using IDbConnection connection = CreateConnection();
            return await connection.ExecuteAsync(sqlCommand, parameters);
        }

        public async Task<int> ExecuteScalarAsync(string sqlCommand, object param = null)
        {
            using IDbConnection connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sqlCommand, param);
        }

        public async Task ExecuteAsync(string sqlCommand, object param = null)
        {
            using IDbConnection connection = CreateConnection();
            await connection.ExecuteAsync(sqlCommand, param);
        }

        public async Task ExecuteAsync(Dictionary<string, List<dynamic>> input)
        {
            using IDbConnection connection = CreateConnection();
            using (var transaction = connection.BeginTransaction())
            try
            {
                foreach (var item in input)
                    await connection.ExecuteAsync(item.Key, item.Value, transaction);
             
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }
        }

        protected async Task<IEnumerable<TObject>> QueryAsync<TObject>(string sql, object param = null)
        {
            using IDbConnection connection = CreateConnection();
            return await connection.QueryAsync<TObject>(sql, param);
        }

        protected async Task<TObject> QueryFirstOrDefaultAsync<TObject>(string sql, object param = null)
        {
            using IDbConnection connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TObject>(sql, param);
        }

        protected async Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null) where TReturn : class
        {
            using IDbConnection connection = CreateConnection();
            return await connection.QueryAsync(sql, map, param, commandTimeout: 0);
        }

        protected async Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null) where TReturn : class
        {
            using IDbConnection connection = CreateConnection();
            return await connection.QueryAsync(sql, map, param, commandTimeout: 0);
        }

        private IDbConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
