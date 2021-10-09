using _1.MCargoExpress.Domain;
using _2._2.MCargoExpress.Persistence.Settings;
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

            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="context">IConexion</param>
            /// Francisco Rios
            public Manejador(IConexion context)
            {
                _context = context;
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
                var query = new TipoPersona

                {
                    Tipo = request.Tipo,
                    Estado = request.Estatus

                };
                _context.TipoPersona.Add(query);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No crear el tipo persona");
            }
        }
    }
}
