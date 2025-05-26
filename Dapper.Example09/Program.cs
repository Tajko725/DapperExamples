using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 9 - Mapowanie do klas"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            string sql = "SELECT Id, Name FROM Users";
            var previews = connection.Query<UserPreview>(sql).ToList();

            Console.WriteLine("Podgląd użytkowników:");
            foreach (var preview in previews)
                Console.WriteLine($"{preview.Id}: {preview.Name}");
        }
    }
}