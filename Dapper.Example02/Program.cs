using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 2 - Połączenie z bazą danych"));
            using var connection = DbConnectionFactory.CreateConnection(); // nie trzeba wywoływać connection.Close(), ponieważ using automatycznie zamknie połączenie
            Console.WriteLine($"Stan połączenia: {connection.State}");
            connection.Open();
            Console.WriteLine($"Po otwarciu: {connection.State}");
        }
    }
}