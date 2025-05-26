using System.Data;

namespace Dapper.Shared.Db
{
    /// <summary>
    /// Interfejs definiujący fabrykę połączeń do bazy danych.
    /// </summary>
    public interface ISqlConnectionFactory
    {
        /// <summary>
        /// Tworzy i zwraca nowe połączenie do bazy danych.
        /// </summary>
        /// <returns>Obiekt połączenia typu IDbConnection.</returns>
        IDbConnection Create();
    }
}