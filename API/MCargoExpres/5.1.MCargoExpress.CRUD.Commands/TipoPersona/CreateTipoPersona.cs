using _1.MCargoExpress.Domain;
using _2._2.MCargoExpress.Persistence.Settings;
using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using _4.MCargoExpress.Aplication.Logic;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._1.MCargoExpress.CRUD.Commands._TipoPersona
{
    /// <summary>
    /// Mediador para crear un Tipo de Persona
    /// </summary>
    /// Francisco Rios
    public class CreateTipoPersona
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<TipoPersonaDto>
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
        public class Manejador : IRequestHandler<Ejecuta, TipoPersonaDto>
        {
            private readonly ITipoPersonaService tipoPersonaService;

            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_tipoPersonaService">Service de tipo persona</param
            /// Francisco Rios
            public Manejador(ITipoPersonaService _tipoPersonaService)
            {
                tipoPersonaService = _tipoPersonaService;

            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Promesa de tipo persona</returns>
            /// Franciso Rios
            public async Task<TipoPersonaDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = new TipoPersonaDto
                {
                    Tipo = request.Tipo,
                    Estado = request.Estatus
                };

                var valor = await tipoPersonaService.AddTipoPersonaAsync(query);
                if (valor != null)
                {
                    return valor;
                }
                throw new Exception("Error al crear el tipo persona");
            }
        }
    }
}
