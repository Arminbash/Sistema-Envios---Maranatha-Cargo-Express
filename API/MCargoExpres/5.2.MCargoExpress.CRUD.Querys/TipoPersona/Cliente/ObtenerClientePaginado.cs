using _3._1.MCargoExpress.Dtos;
using _3._1.MCargoExpress.Dtos.Base;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys.TipoPersona.Cliente
{
    /// <summary>
    /// Mediador que obtiene los  clientes paginados
    /// </summary>
    /// Francisco Rios
  public  class ObtenerClientePaginado
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Francisco Rios
        public class Ejecuta : IRequest<PaginationRequestBase<ClienteDto>>
        {
            public PaginationDto pagination { get; set; }
        }
        /// <summary>
        /// Validaciones de campos para paginar
        /// </summary>
        /// Francisco Rios
        public class CreateValidacion : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            public CreateValidacion()
            {
                RuleFor(x => x.pagination.page).NotEmpty();
                RuleFor(x => x.pagination.perpage).NotEmpty();
            }
            /// <summary>
            /// Clase encargada de ejecutar el contrato
            /// </summary>
            /// Francisco Rios
            public class Manejador : IRequestHandler<Ejecuta, PaginationRequestBase<ClienteDto>>
            {
                private readonly IClienteService _clienteService;
                /// <summary>
                /// constructor para injectar las dependencias
                /// </summary>
                /// <param name="clienteService">Service de  cliente</param>
                public Manejador(IClienteService clienteService)
                {
                    _clienteService = clienteService;
                }
                /// <summary>
                /// Metodo que ejecuta el contrato y devuelve la promesa
                /// </summary>
                /// <param name="request">Clase modelo</param>
                /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
                /// <returns>Lista de cliente paginados</returns>
                /// Francisco Rios
                public async Task<PaginationRequestBase<ClienteDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
                {
                    var query = await _clienteService.GetClientePaginadoAsync(request.pagination);
                    return query;
                }
            }
        }
    }
}
