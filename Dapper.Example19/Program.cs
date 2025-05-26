using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 19 - Dynamiczne zapytania"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            string sql = "SELECT Id, Name, Email FROM Users";
            // var results = connection.Query(sql).ToList(); // Zwraca List<dynamic>

            IEnumerable<dynamic> results = [.. connection.Query(sql)]; // Zwraca IEnumerable<dynamic>

            Console.WriteLine("Wyniki zapytania dynamicznego:");
            foreach (var row in results)
            {
                Console.WriteLine($"{row.Id}: {row.Name} - {row.Email}");
            }
        }
    }
}