using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using _2._2.MCargoExpress.Persistence.Settings;
using Microsoft.EntityFrameworkCore;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using _3._1.MCargoExpress.Dtos;

namespace _5._2.MCargoExpress.CRUD.Querys._QTipoPersona
{
    /// <summary>
    /// Mediador para lista de Tipo Persona
    /// </summary>
    /// Francisco Rios
    public class ObtenerTipoPersona
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta : IRequest<List<TipoPersonaDto>>
        {
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, List<TipoPersonaDto>>
        {
            private readonly IConexion context;
            private readonly ITipoPersonaService ItipoPersonaService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_context">Contexto Base</param>
            /// Francisco Rios
            public Manejador(IConexion _context, ITipoPersonaService _ItipoPersonaService)
            {
                context = _context;
                ItipoPersonaService = _ItipoPersonaService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Lista de Tipo Persona</returns>
            /// Francisco Rios
            public async Task<List<TipoPersonaDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await ItipoPersonaService.GetAllTipoPersonaAsync();
                return query.ToList();
            }
        }
    }
}
