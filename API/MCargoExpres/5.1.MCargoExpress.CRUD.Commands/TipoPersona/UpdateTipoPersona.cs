using _2._2.MCargoExpress.Persistence.Settings;
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

namespace _5._1.MCargoExpress.CRUD.Commands._TipoPersona
{
    /// <summary>
    /// Mediador para actualizar un Tipo de Persona
    /// </summary>
    /// Francisco Rios
    public class UpdateTipoPersona
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta :IRequest<TipoPersonaDto>
        {
            public int Id{ get; set; }
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
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta,TipoPersonaDto>
        {
            private readonly ITipoPersonaService tipoPersonaService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_tipoPersonaService">Service de tipo persona</param>
            /// Francisco Rios
            public Manejador( ITipoPersonaService _tipoPersonaService)
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
                var query = await tipoPersonaService.GetTipoPersonaPorIdAsync(request.Id);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Error al editar el tipo persona" });
                }

                var UpdateQuery = new TipoPersonaDto
                {
                    Id = query.Id,
                   Tipo= request.Tipo,
                   Estado = request.Estado ?? query.Estado
                };
                
                var valor = await tipoPersonaService.UpdateTipoPersonaAsync(UpdateQuery);
                if (valor != null)
                {
                    return valor;
                }
                throw new Exception("Error al actualizar");
            }
        }

    }
}
