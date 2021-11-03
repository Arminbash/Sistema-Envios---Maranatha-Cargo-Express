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

namespace _5._2.MCargoExpress.CRUD.Querys.Traduccion
{
    /// <summary>
    /// Mediador Obtiene las traduccions por llave y clave
    /// </summary>
    /// Francisco Rios
    public class ObtenerTraduccionXClave
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        /// 
        public class Ejecuta : IRequest<TraduccionDto>
        {
            
            public string Llave { get; set; }
           
            public string Lang { get; set; }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, TraduccionDto>
        {
            
            private readonly ITraduccionService _ItraduccionService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_ItraduccionService">Contexto Base</param>
            /// Francisco Rios
            public Manejador(ITraduccionService ItraduccionService)
            {

                _ItraduccionService = ItraduccionService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Traduccion</returns>
            /// Francisco Rios
            public async Task<TraduccionDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await _ItraduccionService.GetTraduccionPorClaveAsync(request.Llave,request.Lang);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el Tipo Perosna" });
                }
                return query;
            }
        }
    }
}
