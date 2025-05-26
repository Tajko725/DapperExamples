using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 10 - Wiele wyników (QueryMultiple)"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            string sql = @"
            SELECT * FROM Users;
            SELECT COUNT(*) FROM Users;";

            using var multi = connection.QueryMultiple(sql);
            var users = multi.Read<User>().ToList();
            var count = multi.ReadSingle<int>();

            Console.WriteLine($"Użytkowników: {count}");
            foreach (var user in users)
                Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
        }
    }
}
