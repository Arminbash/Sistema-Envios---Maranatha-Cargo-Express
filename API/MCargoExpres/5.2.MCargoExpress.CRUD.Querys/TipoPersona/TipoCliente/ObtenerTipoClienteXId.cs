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

namespace _5._2.MCargoExpress.CRUD.Querys.TipoPersona_.TipoCliente
{
  public  class ObtenerTipoClienteXId
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta : IRequest<TipoClienteDto>
        {
            public int Id { get; set; }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, TipoClienteDto>
        {
          
            private readonly ITipoClienteService ItipoClienteService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_ItipoClienteServices">Contexto Base</param>
            /// Francisco Rios
            public Manejador(ITipoClienteService _ItipoClienteServices)
            {
                ItipoClienteService = _ItipoClienteServices;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Tipo Persona</returns>
            /// Francisco Rios
            public async Task<TipoClienteDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await ItipoClienteService.GetTipoClientePorIdAsync(request.Id);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el Tipo Perosna" });
                }
                return query;
            }
        }
    }
}
