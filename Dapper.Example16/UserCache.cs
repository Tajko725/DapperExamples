using Dapper.Shared.Models;
using System.Data;

namespace Dapper.Example16
{
    /// <summary>
    /// Bufor wyników zapytania o użytkowników.
    /// </summary>
    public static class UserCache
    {
        private static List<User>? _cachedUsers;

        /// <summary>
        /// Zwraca listę użytkowników z pamięci podręcznej lub bazy danych.
        /// </summary>
        public static List<User> GetUsers(IDbConnection connection)
        {
            if (_cachedUsers is not null)
                return _cachedUsers;

            // Równoważne ToList() – tworzy nową List<User> z wyników zapytania (C# 12 operator spread)
            _cachedUsers = [.. connection.Query<User>("SELECT * FROM Users")];

            return _cachedUsers;
        }

        /// <summary>
        /// Czyści pamięć podręczną użytkowników.
        /// </summary>
        public static void Clear() => _cachedUsers = null;
    }
}