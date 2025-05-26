using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 3 - Pobieranie pojedynczego rekordu"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            // Pobranie użytkownika o ID = 1
            string sql = "SELECT * FROM Users WHERE Id = @Id";
            var user = connection.QuerySingleOrDefault<User>(sql, new { Id = 1 });
            if (user != null)
            {
                Console.WriteLine($"Użytkownik: {user.Name}, Email: {user.Email}");
            }
            else
            {
                Console.WriteLine("Nie znaleziono użytkownika.");
            }
        }
    }
}
