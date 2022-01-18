using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys._TipoPersona.Empleado
{
    /// <summary>
    /// Mediador para lista de Empelado
    /// </summary>
    /// Francisco Rios
    public class ObtenerEmpleado
    {

        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta: IRequest<List<EmpleadoDto>>
        {
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Francisco Rios
        public class Manejador : IRequestHandler<Ejecuta, List<EmpleadoDto>>
        {
            private readonly IEmpleadoService IempleadoService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="IempleadoService"></param>
            /// Francisco Rios
            public Manejador (IEmpleadoService _IempleadoService)
            {
                IempleadoService = _IempleadoService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Lista de Tipo Persona</returns>
            /// Francisco Rios
            public async Task<List<EmpleadoDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await IempleadoService.GetAllEmpleadoAsync();
                return query.ToList();
            }
        }
    }
}
