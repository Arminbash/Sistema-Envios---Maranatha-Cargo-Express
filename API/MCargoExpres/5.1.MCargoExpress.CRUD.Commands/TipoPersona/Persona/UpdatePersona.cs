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

namespace _5._1.MCargoExpress.CRUD.Commands.TipoPersona.Persona
{
    /// <summary>
    /// Mediador para actualizar una persona
    /// </summary>
    /// Francisco Rios
    public class UpdatePersona
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<PersonaDto>
        {
            public int Id { get; set; }
            public string PrimerNombre { get; set; }
            public string SegundoNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string Correo { get; set; }
            public string Cedula { get; set; }
            public string Direccion { get; set; }
            public int? Telefono { get; set; }
            public int? TipoPersonaId { get; set; }
            public bool Estado { get; set; }
        }
        public class CreateValidacion : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            public CreateValidacion()
            {
                RuleFor(x => x.Id).NotEmpty();
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
        public class Manejador : IRequestHandler<Ejecuta,PersonaDto>
        {
            private readonly IPersonaService personaServices;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_personaService">Service de persona</param>
            /// Francisco Rios
            public Manejador(IPersonaService _personaService)
            {
                personaServices = _personaService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Promesa de persona</returns>
            /// Franciso Rios
            public async Task<PersonaDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await personaServices.GetPersonaPorIdAsync(request.Id);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Persona no encontrada" });
                }

                var UpdateQuery = new PersonaDto
                {
                    Id = request.Id,
                    PrimerNombre = request.PrimerNombre ?? query.PrimerNombre,
                    SegundoNombre = request.SegundoNombre ?? query.SegundoNombre,
                    PrimerApellido = request.PrimerApellido ?? query.PrimerApellido,
                    SegundoApellido = request.SegundoApellido ?? query.SegundoApellido,
                    Correo = request.Correo?? query.Correo,
                    Cedula = request.Cedula ?? query.Cedula,
                    Direccion = request.Direccion ?? query.Direccion,
                    Telefono = request.Telefono ??  query.Telefono,
                    TipoPersonaId = request.TipoPersonaId  ?? query.TipoPersonaId,
                    Estado = request.Estado
                };
                var valor = await personaServices.UpdatePersonaAsync(UpdateQuery);
                if (valor != null)
                {
                    return valor;
                }
                throw new Exception("error al actualizar");
            }
        }
    }
}
