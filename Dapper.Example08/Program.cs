using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 8 - Użycie parametrów"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            // Zapytanie z parametrem LIKE
            string sql = "SELECT * FROM Users WHERE Name LIKE @Pattern";

            var users = connection.Query<User>(sql, new { Pattern = "%Anna%" }).ToList();

            Console.WriteLine("Znalezieni użytkownicy:");
            foreach (var user in users)
                Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
        }
    }
}
