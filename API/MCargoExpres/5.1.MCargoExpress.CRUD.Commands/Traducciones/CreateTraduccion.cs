using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._1.MCargoExpress.CRUD.Commands.Traducciones
{
    /// <summary>
    /// Mediador Crear Traduciones
    /// </summary>
    /// Francisco Rios
    public class CreateTraduccion
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<TraduccionDto>
        {
            public string Llave { get; set; }

            public string Valor { get; set; }

            public string Lang { get; set; }

            public string Tipo { get; set; }

            public bool Estado { get; set; }
        }
        public class CreateValidacion : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            public CreateValidacion()
            {
                RuleFor(x => x.Llave).NotEmpty();
                RuleFor(x => x.Valor).NotEmpty();
                RuleFor(x => x.Lang).NotEmpty();
                RuleFor(x => x.Tipo).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta,TraduccionDto>
        {
           
            private readonly ITraduccionService _ITraduccionService;

            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_ITraduccionService">Traduccion</param
            /// Francisco Rios
            public Manejador(ITraduccionService ItraduccionService)
            {

                _ITraduccionService = ItraduccionService;

            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Promesa de Traduccion</returns>
            /// Franciso Rios

            public async Task<TraduccionDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = new TraduccionDto
                {
                    Llave = request.Llave,
                    Valor = request.Valor,
                    Lang =request.Lang,
                    Tipo = request.Tipo,
                    Estado = request.Estado

                };
                var valor = await _ITraduccionService.AddTraduccionAsync(query);
                if (valor != null)
                {
                    return valor;
                }
                throw new Exception("No crear el tipo persona");
            }
        }



    }
}
