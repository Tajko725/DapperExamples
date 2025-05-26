using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 7 - Usuwanie danych"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            string sql = "DELETE FROM Users WHERE Id = @Id";
            var deleted = connection.Execute(sql, new { Id = 1 });

            Console.WriteLine($"Usunięto wierszy: {deleted}");
        }
    }
}