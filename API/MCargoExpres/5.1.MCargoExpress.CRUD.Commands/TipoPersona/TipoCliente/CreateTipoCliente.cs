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
    /// Mediador Crear Tipo Cliente
    /// </summary>
    /// Francisco Rios
    public class CreateTipoCliente
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest
        {
            public string Tipo { get; set; }
            public bool Estatus { get; set; }
        }
        public class CreateValidacion : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            public CreateValidacion()
            {
                RuleFor(x => x.Tipo).NotEmpty();
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta>
        {
            
            private readonly ITipoClienteService _ItipoClienteService;

            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="ItipoClienteService">TipoPersonaService</param
            /// Francisco Rios
            public Manejador( ITipoClienteService ItipoClienteService)
            {
               
                _ItipoClienteService = ItipoClienteService;

            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Promesa de tipo persona</returns>
            /// Franciso Rios

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = new TipoClienteDto

                {
                    Tipo = request.Tipo,
                    Estado = request.Estatus

                };
                //_context.TipoPersona.Add(query);

                //  _tipoPersonaService.AddTipoPersonaAsync(query);
                var valor = await _ItipoClienteService.AddTipoClienteAsync(query);
                if (valor != null)
                {
                    return Unit.Value;
                }
                throw new Exception("No crear el tipo persona");
            }
        }
    }
}
