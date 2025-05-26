using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example12
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 12 - Metody asynchroniczne (QueryAsync, ExecuteAsync)"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            var users = (await connection.QueryAsync<User>("SELECT * FROM Users")).ToList();

            Console.WriteLine("Asynchroniczne pobieranie użytkowników:");
            foreach (var user in users)
                Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
        }
    }
}