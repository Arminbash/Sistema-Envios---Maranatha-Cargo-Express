using _1.MCargoExpress.Domain;
using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys._TipoPersona._Personas
{
    /// <summary>
    /// Mediador para lista de  Persona
    /// </summary>
    /// Francisco Rios
    public class ObtenerPersona
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta : IRequest<List<PersonaDto>>
        {

        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta,List<PersonaDto>>
        {
            private readonly IPersonaService IpersonaService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="IpersonaService">Contexto Base</param>
            /// Francisco Rios
            public Manejador(IPersonaService _IpersonaService)
            {
                IpersonaService = _IpersonaService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Lista de Persona</returns>
            /// Francisco Rios
            public async  Task<List<PersonaDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await IpersonaService.GetAllTipoPersonaAsync();
                return query.ToList();
            }
        }
    }
}
