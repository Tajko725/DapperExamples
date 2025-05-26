using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 15 - Obsługa wielu zapytań w jednym wywołaniu"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            string sql = @"
            SELECT COUNT(*) FROM Users;
            SELECT COUNT(*) FROM Orders;
            SELECT TOP 1 * FROM Users ORDER BY Id DESC;";

            using var multi = connection.QueryMultiple(sql);
            var userCount = multi.ReadSingle<int>();
            var orderCount = multi.ReadSingle<int>();
            var lastUser = multi.ReadSingle<User>();

            Console.WriteLine($"Użytkowników: {userCount}, Zamówień: {orderCount}");
            Console.WriteLine($"Ostatni użytkownik: {lastUser.Name}, Email: {lastUser.Email}");
        }
    }
}