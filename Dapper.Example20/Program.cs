using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 20 - Własna implementacja SqlConnectionFactory"));

            // Wybór typu bazy – można dynamicznie ustawiać z pliku konfiguracyjnego lub argumentu
            string dbType = "sqlserver"; // lub: "sqlite", "mysql"

            // Przykładowe connection stringi – dostosuj do środowiska
            ISqlConnectionFactory factory = dbType switch
            {
                "sqlserver" => new SqlServerConnectionFactory("Server=localhost;Database=DapperTestDb;Trusted_Connection=True;TrustServerCertificate=True;"),
                "mysql" => new MySqlConnectionFactory("Server=localhost;Database=DapperTestDb;Uid=root;Pwd=yourpassword;"),
                "sqlite" => new SqliteConnectionFactory("Data Source=DapperTestDb.db"),
                _ => throw new NotSupportedException("Nieobsługiwany typ bazy danych.")
            };

            using var connection = factory.Create();
            connection.Open();

            // Wypisanie użytkowników
            var users = connection.Query<User>("SELECT * FROM Users").ToList();

            Console.WriteLine($"Lista użytkowników dla bazy danych '{dbType}':");
            foreach (var user in users)
                Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
        }
    }
}