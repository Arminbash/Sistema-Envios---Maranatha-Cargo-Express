using _1.MCargoExpress.Domain;
using _2._2.MCargoExpress.Persistence.Settings;
using _3._1.MCargoExpress.Dtos;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._1.MCargoExpress.CRUD.Commands._TipoPersona._Persona
{
    /// <summary>
    /// Mediador Crear  Persona
    /// </summary>
    /// Francisco Rios
    public class CreatePersona 
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest  {
        
            public string PrimerNombre { get; set; }
            public string SegundoNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string Correo { get; set; }
            public string Cedula { get; set; }
            public string Direccion { get; set; }
            public int Telefono { get; set; }
            public int TipoPersonaId { get; set; }
            public bool Estado { get; set; }
        }
        public class CreateValidacion : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            public CreateValidacion (){
                RuleFor(x => x.PrimerNombre).NotEmpty();
                RuleFor(x => x.SegundoNombre).NotEmpty();
                RuleFor(x => x.PrimerApellido).NotEmpty();
                RuleFor(x => x.SegundoApellido).NotEmpty();
                RuleFor(x => x.Correo).NotEmpty();
                RuleFor(x => x.Cedula).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
                RuleFor(x => x.TipoPersonaId).NotEmpty();

            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IConexion context;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="context">IConexion</param>
            /// Francisco Rios
            public Manejador(IConexion _context)
            {
                context = _context;
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
                var query = new Persona
                {
                    PrimerNombre = request.PrimerNombre,
                    SegundoNombre = request.SegundoNombre,
                    PrimerApellido = request.PrimerApellido,
                    SegundoApellido = request.SegundoApellido,
                    Correo = request.Correo,
                    Cedula = request.Cedula,
                    Direccion = request.Direccion,
                    Telefono = request.Telefono,
                    TipoPersonaId = request.TipoPersonaId,
                    Estado = true
                };
                context.Persona.Add(query);
                var valor = await context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se logro ingresar la persona");

            }
        }
    }
}
