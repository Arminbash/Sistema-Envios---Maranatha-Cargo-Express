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

namespace _5._2.MCargoExpress.CRUD.Querys.TipoPersona2.Cliente
{
    /// <summary>
    /// Mediador que obtiene el Cliente por Id
    /// </summary>
    /// Francisco Rios
    public class ObtenerClientePorId
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta : IRequest<ClienteDto>
        {
            public int Id { get; set; }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, ClienteDto>
        {
            private readonly IClienteService clienteService;

            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_clienteService">Service de cliente</param>
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
            /// <returns>Cliente</returns>
            /// Francisco Rios
            public async Task<ClienteDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = clienteService.GetClientePorIdAsync(request.Id);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el cliente" });
                }
                return await query;
            }
        }
    }
}
