using Dapper.Shared.Models;

namespace Dapper.Example18
{
    /// <summary>
    /// Model użytkownika wykorzystujący typ EmailAddress jako ValueObject.
    /// </summary>
    public class UserWithValueObject
    {
        /// <summary>Unikalny identyfikator użytkownika.</summary>
        public int Id { get; set; }
        /// <summary>Imię i nazwisko użytkownika.</summary>
        public string Name { get; set; }
        /// <summary>Adres e-mail użytkownika jako typ EmailAddress.</summary>
        public EmailAddress Email { get; set; }
    }
}