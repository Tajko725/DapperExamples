using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 6 - Aktualizacja danych"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            string sql = "UPDATE Users SET Email = @Email WHERE Id = @Id";
            var result = connection.Execute(sql, new { Id = 1, Email = "nowy.email@example.com" });

            Console.WriteLine($"Zaktualizowano wierszy: {result}");
        }
    }
}
