using Microsoft.Data.Sqlite;
using System.Data;

namespace Dapper.Shared.Db
{
    /// <summary>
    /// Fabryka połączeń dla lokalnej bazy SQLite.
    /// </summary>
    public class SqliteConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        /// <summary>
        /// Inicjalizuje fabrykę z connection stringiem dla SQLite.
        /// </summary>
        /// <param name="connectionString">Ścieżka do pliku bazy SQLite.</param>
        public SqliteConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Zwraca nowe połączenie do SQLite.
        /// </summary>
        public IDbConnection Create()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}