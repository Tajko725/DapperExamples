namespace Dapper.Example18
{
    /// <summary>
    /// Obiekt wartości reprezentujący adres e-mail z walidacją.
    /// </summary>
    public readonly struct EmailAddress
    {
        /// <summary>Wartość adresu e-mail jako tekst.</summary>
        public string Value { get; }

        /// <summary>
        /// Tworzy instancję adresu e-mail i sprawdza jego poprawność.
        /// </summary>
        /// <param name="value">Tekstowy adres e-mail</param>
        /// <exception cref="ArgumentException">Rzucany, gdy adres jest nieprawidłowy</exception>
        public EmailAddress(string value)
        {
            if (!value.Contains('@'))
                throw new ArgumentException("Nieprawidłowy email.");
            Value = value;
        }

        /// <summary>
        /// Zwraca adres e-mail jako tekst.
        /// </summary>
        public override string ToString() => Value;
    }
}