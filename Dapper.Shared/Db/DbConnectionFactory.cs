using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.Shared.Db
{
    /// <summary>
    /// Klasa pomocnicza do uzyskiwania połączenia z bazą danych.
    /// </summary>
    public static class DbConnectionFactory
    {
        /// <summary>
        /// Łańcuch połączenia do lokalnej bazy danych.
        /// </summary>
        private const string ConnectionString = "Server=localhost;Database=DapperTestDb;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// Zwraca nowe połączenie z bazą danych SQL Server.
        /// </summary>
        /// <returns>Obiekt połączenia IDbConnection</returns>
        public static IDbConnection CreateConnection()
        {
            // Tworzymy nowe połączenie z SQL Server
            return new SqlConnection(ConnectionString);
        }
    }
}