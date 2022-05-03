using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using _4.MCargoExpress.Aplication.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._1.MCargoExpress.CRUD.Commands.TipoPersona.TipoCliente
{
    /// <summary>
    /// Mediador para actualizar un Tipo de Cliente
    /// </summary>
    /// Francisco Rios
    public class UpdateTipoCliente
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<TipoClienteDto>
        {
            public int Id { get; set; }
            public string Tipo { get; set; }
            public bool? Estado { get; set; }
        }
        public class CreateValidation : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            public CreateValidation()
            {
                RuleFor(x => x.Tipo).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta,TipoClienteDto>
        {
            private readonly ITipoClienteService tipoClienteService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_tipoClienteService">Service de tipo cliente</param>
            /// Francisco Rios
            public Manejador( ITipoClienteService _tipoClienteService)
            {

                tipoClienteService = _tipoClienteService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Promesa de tipo persona</returns>
            /// Franciso Rios
            public async Task<TipoClienteDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await tipoClienteService.GetTipoClientePorIdAsync(request.Id);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Error al editar el tipo cliente" });
                }

                var UpdateQuery = new TipoClienteDto
                {
                    Id = query.Id,
                    Tipo = request.Tipo,
                    Estado = request.Estado ?? query.Estado
                };

                var valor = await tipoClienteService.UpdateTipoClienteAsync(UpdateQuery);
                if (valor != null)
                {
                    return valor;
                }
                throw new Exception("error al actualizar");
            }
        }
    }
}
