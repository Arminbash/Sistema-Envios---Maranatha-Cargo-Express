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

namespace _5._1.MCargoExpress.CRUD.Commands.TipoPersona.TipoCliente.Cliente
{
    /// <summary>
    /// Mediador para actualizar un Cliente
    /// </summary>
    /// Francisco Rios
    public class UpdateCliente
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<ClienteDto>
        {
            public int Id { get; set; }
            public int PersonaId { get; set; }

            public int TipoClienteId { get; set; }

            public bool Estado { get; set; }
        }
        public class CreateValidacion : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            public CreateValidacion()
            {
                RuleFor(x => x.PersonaId).NotEmpty();
                RuleFor(x => x.TipoClienteId).NotEmpty();
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta,ClienteDto>
        {
           
            private readonly IClienteService clienteService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_clienteService">Service de cliente</param>
            /// Francisco Rios
            public Manejador(IClienteService _clienteService)
            {

                clienteService = _clienteService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Promesa de Cliente</returns>
            /// Franciso Rios
            public async Task<ClienteDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await clienteService.GetClientePorIdAsync(request.Id);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Cliente no encontrado" });
                }

                var UpdateQuery = new ClienteDto
                {
                    Id = request.Id,
                    PersonaId = request.PersonaId ,
                    TipoClienteId = request.TipoClienteId,
                    Estado = request.Estado
                };
                var valor = await clienteService.UpdateClienteAsync(UpdateQuery);
                if (valor != null)
                {
                    return valor;
                }
                throw new Exception("error al actualizar");
            }
        }
    }
}
