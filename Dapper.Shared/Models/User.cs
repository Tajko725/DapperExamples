namespace Dapper.Shared.Models
{
    /// <summary>
    /// Klasa reprezentująca użytkownika.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identyfikator użytkownika.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Imię i nazwisko użytkownika.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Adres e-mail użytkownika.
        /// </summary>
        public string Email { get; set; }
    }
}