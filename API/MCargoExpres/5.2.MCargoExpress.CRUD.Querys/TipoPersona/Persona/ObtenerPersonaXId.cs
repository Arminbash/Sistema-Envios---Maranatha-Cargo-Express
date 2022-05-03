using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using _4.MCargoExpress.Aplication.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys._TipoPersona._Persona
{
    /// <summary>
    /// Mediador que obtiene la persona por Id
    /// </summary>
    /// Francisco Rios
    public class ObtenerPersonaXId
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta :IRequest<PersonaDto>
        {
            public int Id { get; set; }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, PersonaDto>
        {
            private readonly IPersonaService personaService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_IPersonaService">Service de persona</param>
            /// Francisco Rios
            public Manejador (IPersonaService _IPersonaService)
            {
                personaService = _IPersonaService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Persona</returns>
            /// Francisco Rios
            public async Task<PersonaDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await personaService.GetPersonaPorIdAsync(request.Id);
                if( query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe la Persona" });

                }
                return query;
            }
        }
    }
}
