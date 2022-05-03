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

namespace _5._2.MCargoExpress.CRUD.Querys.TipoPersona
{
    /// <summary>
    /// Mediador que obtiene los tipo de personas paginados
    /// </summary>
    /// Johnny Arcia
    public class ObtenerTipoPersonaPaginado
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Johnny Arcia
        public class Ejecuta : IRequest<PaginationRequestBase<TipoPersonaDto>>
        {
            public PaginationDto pagination { get; set; }
        }
        /// <summary>
        /// Validaciones de campos para paginar
        /// </summary>
        /// Johnny Arcia
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
        }
        /// <summary>
        /// Clase encargada de ejecutar el contrato
        /// </summary>
        /// Johnny Arcia
            public class Manejador : IRequestHandler<Ejecuta, PaginationRequestBase<TipoPersonaDto>>
        {
            private readonly ITipoPersonaService _tipoPersonaService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="tipoPersonaService">Service de tipo persona</param>
            public Manejador(ITipoPersonaService tipoPersonaService)
            {
                _tipoPersonaService = tipoPersonaService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Lista de tipo persona paginados</returns>
            /// Johnny Arcia
            public async Task<PaginationRequestBase<TipoPersonaDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await _tipoPersonaService.GetTipoPersonaPaginadoAsync(request.pagination);
                return query;
            }
        }
    }
}
