using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys.TipoPersona2.Empleado
{
    /// <summary>
    /// Mediador para lista de Cliente
    /// </summary>
    /// Francisco Rios
    public class ObtenerCliente
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta : IRequest<List<ClienteDto>>
        {
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, List<ClienteDto>>
        {
            private readonly IClienteService clienteService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="clienteService"></param>
            /// Francisco Rios
            public Manejador(IClienteService _clienteService)
            {
                clienteService = _clienteService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Lista de Tipo Cliente</returns>
            /// Francisco Rios
            public async Task<List<ClienteDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await clienteService.GetAllClientesAsync();
                return query.ToList();
            }
        }

    }
}
