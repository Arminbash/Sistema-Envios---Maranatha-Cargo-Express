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

namespace _5._2.MCargoExpress.CRUD.Querys._TipoPersona.Empleado
{
    /// <summary>
    /// Mediador que obtiene el empleado por Id
    /// </summary>
    /// Francisco Rios
    public class ObtenerEmpleadoPorId
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta :IRequest<EmpleadoDto>
        {
            public int Id { get; set; }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, EmpleadoDto>
        {
            private readonly IEmpleadoService empleadoService;

            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_IempleadoService">Service de empleado</param>
            /// Francisco Rios
            public Manejador(IEmpleadoService _IempleadoService)
            {
                empleadoService = _IempleadoService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Empleado</returns>
            /// Francisco Rios
            public async Task<EmpleadoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = empleadoService.GetEmpeladoPorIdAsync(request.Id);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el empleado" });
                }
                return await query;
            }
        }
    }
}
