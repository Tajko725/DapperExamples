using Dapper.Shared.Db;
using Dapper.Shared.Models;
using System.Data;

namespace Dapper.Example13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 13 - Wywołanie procedur składowanych"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            var users = connection.Query<User>("GetUsers", commandType: CommandType.StoredProcedure).ToList();

            Console.WriteLine("Dane z procedury GetUsers:");
            foreach (var user in users)
                Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
        }
    }
}