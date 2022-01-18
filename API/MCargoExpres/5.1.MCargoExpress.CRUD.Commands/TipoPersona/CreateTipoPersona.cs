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
    /// Mediador Crear Tipo Persona
    /// </summary>
    /// Francisco Rios
    public class CreateTipoPersona
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
            private readonly IConexion _context;
            private readonly ITipoPersonaService _ItipoPersonaService;

            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="context">IConexion</param>
             /// <param name="ItipoPersonaService">TipoPersonaService</param
            /// Francisco Rios
            public Manejador(IConexion context,ITipoPersonaService ItipoPersonaService)
            {
                _context = context;
                _ItipoPersonaService = ItipoPersonaService;

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
                var query = new TipoPersonaDto

                {
                    Tipo = request.Tipo,
                    Estado = request.Estatus

                };
                //_context.TipoPersona.Add(query);

              //  _tipoPersonaService.AddTipoPersonaAsync(query);
                var valor = await _ItipoPersonaService.AddTipoPersonaAsync(query);
                if (valor != null)
                {
                    return Unit.Value;
                }
                throw new Exception("No crear el tipo persona");
            }
        }
    }
}
