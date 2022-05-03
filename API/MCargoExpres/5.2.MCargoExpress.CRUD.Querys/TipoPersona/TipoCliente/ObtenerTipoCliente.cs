using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys._TipoPersona_._TipoCliente
{
    /// <summary>
    /// Mediador para lista de Tipo cliente
    /// </summary>
    /// Francisco Rios
    public class ObtenerTipoCliente
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta : IRequest<List<TipoClienteDto>>
        {
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, List<TipoClienteDto>>
        {
            
            private readonly ITipoClienteService tipoClienteService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_ItipoClienteService">Service de tipo cliente</param>
            /// Francisco Rios
            public Manejador(ITipoClienteService _ItipoClienteService)
            {
                tipoClienteService = _ItipoClienteService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Lista de Tipo Persona</returns>
            /// Francisco Rios
            public async Task<List<TipoClienteDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await tipoClienteService.GetAllTipoClienteAsync();
                return query.ToList();
            }
        }
    }
}
