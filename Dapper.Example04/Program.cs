using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 4 - Pobieranie wielu rekordów"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            // Zapytanie SQL pobierające wszystkich użytkowników
            string sql = "SELECT * FROM Users";
            var users = connection.Query<User>(sql).ToList();

            Console.WriteLine("Lista użytkowników:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
            }
        }
    }
}
