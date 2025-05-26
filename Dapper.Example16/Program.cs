using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 16 - Buforowanie zapytań"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            var users = UserCache.GetUsers(connection);
            Console.WriteLine("Pobrano użytkowników z cache:");
            foreach (var user in users)
                Console.WriteLine($"{user.Name} - {user.Email}");

            // UserCache.Clear(); // W razie potrzeby można wyczyścić cache
        }
    }
}
