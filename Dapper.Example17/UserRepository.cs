using Dapper.Shared.Models;
using System.Data;

namespace Dapper.Example17
{
    /// <summary>
    /// Implementacja repozytorium użytkowników z użyciem Dappera.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        /// <summary>
        /// Tworzy instancję repozytorium z przekazanym połączeniem do bazy.
        /// </summary>
        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Pobiera wszystkich użytkowników z tabeli Users.
        /// </summary>
        public List<User> GetAll()
        {
            // Równoważne ToList() – tworzy nową List<User> z wyników zapytania (C# 12 operator spread)
            return [.. _connection.Query<User>("SELECT * FROM Users")];
        }
    }
}