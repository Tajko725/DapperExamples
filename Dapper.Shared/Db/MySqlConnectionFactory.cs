using MySql.Data.MySqlClient;
using System.Data;

namespace Dapper.Shared.Db
{
    /// <summary>
    /// Fabryka połączeń dla MySQL.
    /// </summary>
    public class MySqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        /// <summary>
        /// Inicjalizuje fabrykę z connection stringiem dla MySQL.
        /// </summary>
        /// <param name="connectionString">Łańcuch połączenia do MySQL.</param>
        public MySqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Zwraca nowe połączenie do MySQL.
        /// </summary>
        public IDbConnection Create()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}