using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = _4.MCargoExpress.Aplication.Exceptions.ValidationException;

namespace _4.MCargoExpress.Aplication.Middleware
{
    /// <summary>
    /// Clase para procesar y disparar las validaciones de Fluent Validation
    /// </summary>
    /// <typeparam name="TRequest">Objeto enviado al mediador</typeparam>
    /// <typeparam name="TResponse">Respuesta del mediador</typeparam>
    /// Johnny Arcia
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        /// <summary>
        /// Disparador para conocer los errores y retornarlos como una respuesta
        /// </summary>
        /// <param name="request">Objeto enviado al mediador</param>
        /// <param name="cancellationToken">Cancelar el proceso syncrono</param>
        /// <param name="next">Redireccion para respuesta</param>
        /// <returns>Respuesta del mediador</returns>
        /// <exception cref="ValidationException">Excepcion capturada</exception>
        /// Johnny Arcia
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new
                    {
                        Key = propertyName,
                        Values = errorMessages.Distinct().ToArray()
                    })
                .ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary.Any())
            {
                throw new ValidationException(errorsDictionary);
            }

            return await next();
        }
    }
}
