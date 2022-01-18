using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys.Traduccion
{
    /// <summary>
    /// Mediador para lista de Tipo Persona
    /// </summary>
    /// Francisco Rios
    public class ObtenerTraduccion
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta : IRequest<List<TraduccionDto>>
        {
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, List<TraduccionDto>>
        {
          
            private readonly ITraduccionService ItraduccionService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_context">Contexto Base</param>
            /// Francisco Rios
            public Manejador(ITraduccionService _ItraduccionService)
            {

                ItraduccionService = _ItraduccionService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Lista las traducciones</returns>
            /// Francisco Rios
            public async Task<List<TraduccionDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await ItraduccionService.GetAllTraduccionesAsync();
                return query.ToList();
            }
        }
    }
}
