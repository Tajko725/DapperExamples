using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 17 - Integracja z warstwą repozytorium"));
            using var connection = DbConnectionFactory.CreateConnection();
            var repository = new UserRepository(connection);
            var users = repository.GetAll();

            Console.WriteLine("Użytkownicy z repozytorium:");
            foreach (var user in users)
                Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
        }
    }
}