using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.Shared.Db
{
    /// <summary>
    /// Fabryka połączeń dla SQL Server.
    /// </summary>
    public class SqlServerConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        /// <summary>
        /// Tworzy nową instancję fabryki z łańcuchem połączenia.
        /// </summary>
        /// <param name="connectionString">Łańcuch połączenia do SQL Server.</param>
        public SqlServerConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Zwraca nowe połączenie do SQL Server.
        /// </summary>
        public IDbConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}