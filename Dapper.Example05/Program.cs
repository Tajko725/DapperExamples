using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 5 - Wstawianie danych"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            // Dodanie nowego użytkownika do tabeli
            string sql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            var affectedRows = connection.Execute(sql, new { Name = "Ksuna Yuki", Email = "kasu.yuki@example.com" });

            Console.WriteLine($"Liczba dodanych wierszy: {affectedRows}");
        }
    }
}
