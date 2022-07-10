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

namespace _5._1.MCargoExpress.CRUD.Commands.Factura
{
    /// <summary>
    /// Mediador para crear un  Factura
    /// </summary>
    /// Eddy Vargas
    public class CreateFactura 
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<FacturaDto>
        {
            public int EnvioId { get; set; }

            public int ClienteId { get; set; }

            public DateTime FechaIngreso { get; set; }
            public string Observacion { get; set; }
           
            
        }

        public class CreateValidacion : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            /// 
            public  CreateValidacion()
            {
                RuleFor(x => x.EnvioId).NotEmpty();
                RuleFor(x => x.ClienteId).NotEmpty();
                RuleFor(x => x.FechaIngreso);
                RuleFor(x => x.Observacion).NotEmpty().WithMessage("Por favor escriba una observación");
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta, FacturaDto>
        {
            private readonly IFacturaService facturaService;

            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_clienteService">Servicio de factura</param>
            /// Eddy Vargas
            public Manejador(IFacturaService _facturaService)
            {
                facturaService = _facturaService;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns></returns>
            /// Eddy Vargas
            
            public async Task<FacturaDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = new FacturaDto
                {
                    EnviaId = request.EnvioId,
                    ClienteId = request.ClienteId,
                    Observacion = request.Observacion
                };

                var valor = await facturaService.AddFacturaAsync(query);

                if (valor != null)
                {
                    return valor;
                }

                throw new Exception("No se puede insertar la factura");
            }
        }
    }
}
   
