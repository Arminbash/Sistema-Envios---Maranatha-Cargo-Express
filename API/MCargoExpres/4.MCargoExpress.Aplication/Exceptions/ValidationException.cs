using System.Collections.Generic;
using ApplicationException = _4.MCargoExpress.Aplication.Exceptions.ApplicationException;

namespace _4.MCargoExpress.Aplication.Exceptions
{
    /// <summary>
    /// Clase para manejar la lista de errores encontrados en el middleware
    /// </summary>
    /// Johnny Arcia
    public sealed class ValidationException : ApplicationException
    {
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
            : base("Fallo de validación", "Ocurrio uno o mas errores")
            => ErrorsDictionary = errorsDictionary;

        /// <summary>
        /// Diccionario para los errores de middleware
        /// </summary>
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    }
}
