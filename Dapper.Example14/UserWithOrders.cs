using Dapper.Shared.Models;

namespace Dapper.Example14
{
    /// <summary>
    /// Użytkownik z listą zamówień.
    /// </summary>
    public class UserWithOrders : User
    {
        public List<Order> Orders { get; set; } = [];
    }
}