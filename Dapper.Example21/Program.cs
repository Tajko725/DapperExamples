using Dapper.Shared.Db;
using Dapper.Shared.Models;

namespace Dapper.Example21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Globals.TitleMessage("Przykład 21 - Utworzenie serwisu z metodami CRUD i zaawansowanymi operacjami"));
            using var connection = DbConnectionFactory.CreateConnection();
            var userService = new UserService(connection);

            // Dodanie użytkownika
            userService.Add("Marek Marecki", "marek@example.com");

            // Wyświetlenie wszystkich
            var all = userService.GetAll();
            Console.WriteLine($"Liczba użytkowników: {all.Count}\n");

            Console.WriteLine("Aktualni Użytkownicy:");
            foreach (var u in all)
                Console.WriteLine($"{u.Id}: {u.Name} - {u.Email}");

            var (Count, LastUser) = userService.GetUserStats();
            Console.WriteLine($"Liczba użytkowników: {Count}, Ostatni: {LastUser?.Name}");

            // Edycja
            var user = userService.GetById(7);
            if (user != null)
            {
                user.Email = "zmieniony@example.com";
                userService.Update(user);
            }

            // Usunięcie
            userService.Delete(7);

            Console.WriteLine($"Usunięto użytkownika z Id = 7\n");
            Console.WriteLine("Aktualni Użytkownicy:");
            foreach (var u in all)
                Console.WriteLine($"{u.Id}: {u.Name} - {u.Email}");
        }
    }
}