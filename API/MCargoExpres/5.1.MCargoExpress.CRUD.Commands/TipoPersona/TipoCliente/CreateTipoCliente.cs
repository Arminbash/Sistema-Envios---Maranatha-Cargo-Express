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
    /// Mediador para crear un Tipo de Cliente
    /// </summary>
    /// Francisco Rios
    public class CreateTipoCliente
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<TipoClienteDto>
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
        public class Manejador : IRequestHandler<Ejecuta,TipoClienteDto>
        {
            
            private readonly ITipoClienteService tipoClienteService;

            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_tipoClienteService">Service de tipo cliente</param
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
                var query = new TipoClienteDto
                {
                    Tipo = request.Tipo,
                    Estado = request.Estatus
                };

                var valor = await tipoClienteService.AddTipoClienteAsync(query);
                if (valor != null)
                {
                    return valor;
                }
                throw new Exception("Error al crear el tipo cliente");
            }
        }
    }
}
