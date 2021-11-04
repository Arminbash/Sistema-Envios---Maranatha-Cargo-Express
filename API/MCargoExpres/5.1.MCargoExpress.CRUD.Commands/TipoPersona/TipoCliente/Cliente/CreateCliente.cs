using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._1.MCargoExpress.CRUD.Commands.TipoPersona.TipoCliente
{
    /// <summary>
    /// Mediador Crear  Cliente
    /// </summary>
    /// Francisco Rios
    public class CreateCliente
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest
        {       
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
                RuleFor(x => x.Estado).NotEmpty();
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta>
        {
           
            private readonly IClienteService clienteService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="clienteService">IConexion</param>
            /// Francisco Rios
            public Manejador(IClienteService _clienteService)
            {

                clienteService = _clienteService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns></returns>
            /// Franciso Rios
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = new ClienteDto
                {
                   PersonaId = request.PersonaId,
                   TipoClienteId = request.TipoClienteId,
                   Estado = true
                };

                var valor = await clienteService.AddClienteAsync(query);
                if (valor != null)
                {
                    return Unit.Value;
                }
                throw new Exception("No se logro ingresar la persona");

            }
        }
    }
}
