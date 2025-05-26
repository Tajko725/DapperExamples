using Dapper.Shared.Models;
using System.Data;

namespace Dapper.Example21
{
    /// <summary>
    /// Serwis użytkowników obsługujący operacje CRUD i inne operacje za pomocą Dappera.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IDbConnection _connection;

        /// <summary>
        /// Tworzy instancję serwisu z przekazanym połączeniem do bazy.
        /// </summary>
        /// <param name="connection">Połączenie do bazy danych</param>
        public UserService(IDbConnection connection)
        {
            _connection = connection;
        }

        /// <inheritdoc/>
        public List<User> GetAll()
            => _connection.Query<User>("SELECT * FROM Users").ToList();

        /// <inheritdoc/>
        public User? GetById(int id)
            => _connection.QuerySingleOrDefault<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });

        /// <inheritdoc/>
        public int Add(string name, string email)
        {
            var sql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            return _connection.Execute(sql, new { Name = name, Email = email });
        }

        /// <inheritdoc/>
        public int UpdateUserEmail(int id, string newEmail)
        {
            var sql = "UPDATE Users SET Email = @Email WHERE Id = @Id";
            return _connection.Execute(sql, new { Id = id, Email = newEmail });
        }

        /// <inheritdoc/>
        public void Update(User user)
        {
            string sql = "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id";
            _connection.Execute(sql, user);
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            string sql = "DELETE FROM Users WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }

        /// <inheritdoc/>
        public int Count()
        {
            string sql = "SELECT COUNT(*) FROM Users";
            int count = _connection.ExecuteScalar<int>(sql);
            return count;
        }

        /// <inheritdoc/>
        public (int Count, User? LastUser) GetUserStats()
        {
            string sql = @"
            SELECT COUNT(*) FROM Users;
            SELECT TOP 1 * FROM Users ORDER BY Id DESC;";

            using var multi = _connection.QueryMultiple(sql);
            int count = multi.ReadSingle<int>();
            User? last = multi.ReadSingleOrDefault<User>();
            return (count, last);
        }
    }
}