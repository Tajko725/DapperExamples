using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 14 - Mapowanie relacji 1:1 i 1:N (Multi-mapping)"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            var userDict = new Dictionary<int, UserWithOrders>();

            string sql = @"
            SELECT u.Id, u.Name, u.Email, o.Id, o.Product
            FROM Users u
            LEFT JOIN Orders o ON u.Id = o.UserId";

            var users = connection.Query<UserWithOrders, Order, UserWithOrders>(
                sql,
                (user, order) =>
                {
                    if (!userDict.TryGetValue(user.Id, out var userEntry))
                    {
                        userEntry = user;
                        userEntry.Orders = [];
                        userDict.Add(userEntry.Id, userEntry);
                    }
                    if (order != null)
                        userEntry.Orders.Add(order);
                    return userEntry;
                },
                splitOn: "Id") // Kluczowe jest użycie splitOn: "Id", by Dapper wiedział, gdzie rozpoczyna się drugi obiekt.
                .Distinct()
                .ToList();

            foreach (var u in users)
            {
                Console.WriteLine($"{u.Name} - {u.Email} ({u.Orders.Count} zamówień)");
                foreach (var o in u.Orders)
                    Console.WriteLine($"  - {o.Product}");
            }
        }
    }
}