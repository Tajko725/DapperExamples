using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 18 - Praca z strukturami (np. ValueObject)"));

            // Rejestrujemy handlera raz na początku aplikacji
            SqlMapper.AddTypeHandler(new EmailAddressTypeHandler());

            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            var users = connection.Query<UserWithValueObject>("SELECT * FROM Users").ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.Name} - {user.Email}");
            }
        }
    }
}