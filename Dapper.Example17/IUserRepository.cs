using Dapper.Shared.Models;

namespace Dapper.Example17
{
    /// <summary>
    /// Interfejs repozytorium użytkowników.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Zwraca listę wszystkich użytkowników.
        /// </summary>
        List<User> GetAll();
    }
}