using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 11 - Transakcje SQL"));
            using var connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                int result = connection.Execute("UPDATE Users SET Email = @Email WHERE Id = @Id",
                    new { Id = 2, Email = "rollback@example.com" }, transaction);

                Console.WriteLine($"Użytkownik z Id = 2 zaktualizowany: {(result > 0 ? "Tak" : "Nie")}");

                result = connection.Execute("DELETE FROM Users WHERE Id = @Id",
                    new { Id = 999 }, transaction); // Zakładamy, że ID nie istnieje

                Console.WriteLine($"Użytkownik z Id = 999 usunięty: {(result > 0 ? "Tak" : "Nie")}");
                transaction.Commit();
                Console.WriteLine($"Transakcja zakończona powodzeniem.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd transakcji: {ex.Message}");
                transaction.Rollback();
            }
        }
    }
}