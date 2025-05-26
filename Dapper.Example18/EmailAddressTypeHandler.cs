using Dapper.Shared.Models;
using System.Data;

namespace Dapper.Example18
{
    /// <summary>
    /// TypeHandler Dappera umożliwiający mapowanie struktury EmailAddress.
    /// </summary>
    internal class EmailAddressTypeHandler : SqlMapper.TypeHandler<EmailAddress>
    {
        /// <summary>
        /// Ustawia wartość parametru SQL na podstawie struktury EmailAddress.
        /// </summary>
        /// <param name="parameter">Parametr SQL</param>
        /// <param name="value">Wartość EmailAddress</param>
        public override void SetValue(IDbDataParameter parameter, EmailAddress value)
            => parameter.Value = value.Value;

        /// <summary>
        /// Parsuje wartość z bazy danych na typ EmailAddress.
        /// </summary>
        /// <param name="value">Wartość z bazy</param>
        /// <returns>Instancja EmailAddress</returns>
        public override EmailAddress Parse(object value)
            => new((string)value);
    }
}