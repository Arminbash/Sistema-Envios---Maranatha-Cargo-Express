using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using _4.MCargoExpress.Aplication.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._1.MCargoExpress.CRUD.Commands.Factura
{

    // <summary>
    /// Mediador para editar factura
    /// </summary>
    /// Eddy Vargas
    public class UpdateFactura
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<FacturaDto>
        {
            /// <summary>
            /// Primary key
            /// </summary>

            public int Id { get; set; }

            /// <summary>
            /// clave foranea del Envia
            /// </summary>

            public int EnviaId { get; set; }

            public string CodigoPostal { get; set; }

            public int ClienteId { get; set; }
            /// <summary>
            /// clave foranea del Recibe
            /// </summary>
            public int RecibeId { get; set; }
            /// <summary>
            ///Fecha de la Factura
            /// </summary>
            public DateTime FechaIngreso { get; set; }
            /// <summary>
            /// Tipo Moneda
            /// </summary>
            public string TipoMoneda { get; set; }
            ///<summary>
            /// Tipo Pago
            /// </summary>
            public string TipoPago { get; set; }
            ///<summary>
            /// Observacion
            /// </summary>
            public string Observacion { get; set; }
            /// <summary>
            /// Tasa Cambio
            /// </summary>
            public int TasaCambio { get; set; }
            /// <summary>
            /// propiedad de navegacion de Recive
            /// </summary>

            public ICollection<DetalleFacturaDto> ListaDetalleFactura { get; set; }
        }

        public class CreateValidacion : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            /// 
            public CreateValidacion()
            {
                RuleFor(x => x.EnviaId).NotEmpty();
                RuleFor(x => x.ClienteId).NotEmpty();
                RuleFor(x => x.FechaIngreso);
                RuleFor(x => x.Observacion).NotEmpty().WithMessage("Por favor escriba una observación");
                RuleForEach(x => x.ListaDetalleFactura).NotNull().NotEmpty().WithMessage("Agregue al menos un detalle de producto");


                RuleForEach(x => x.ListaDetalleFactura)
            .Must(y => y.Descripcion != string.Empty && y.Descripcion != null).NotNull().NotEmpty().WithMessage("Por favor escriba una descripcion del producto");
                RuleForEach(x => x.ListaDetalleFactura)
            .Must(y => y.Rate != 0).NotNull().NotEmpty().WithMessage("Por favor escriba el rate");
            }
        }

        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta, FacturaDto>
        {
            private readonly IFacturaService facturaService;

            private readonly IDetalleFacturaService detalleServicio;


            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_facturaServicio">Servicio de factura</param>
            /// Eddy Vargas
            public Manejador(IFacturaService _facturaService, IDetalleFacturaService _detalleFacturaService)
            {
                facturaService = _facturaService;
                detalleServicio = _detalleFacturaService;
            }

            /// <summary>
            /// Metodo que edita el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns></returns>
            /// Eddy Vargas

            public async Task<FacturaDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                            
                var query = await facturaService.GetFacturaPorIdAsync(request.Id);

                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Factura no encontrado" });
                }

                query.Id = request.Id;
                query.TipoMoneda = request.TipoMoneda ?? query.TipoMoneda;
                query.TipoPago = request.TipoPago ?? query.TipoPago;
                query.Observacion = request.Observacion ?? query.Observacion;
                query.DetalleFacturaDto = request.ListaDetalleFactura;

                var valor = await facturaService.UpdateFacturaAsync(query);

                foreach (var item in request.ListaDetalleFactura)
                {
                    DetalleFacturaDto detalle;
                    detalle = new DetalleFacturaDto
                    {
                        Id = item.Id,
                        FacturaId = valor.Id,
                        Descripcion = item.Descripcion,
                        Rate = item.Rate,
                        LBS = item.LBS,
                        VOL = item.VOL,
                        IVA = item.IVA,
                        Estado = true
                    };
                    await detalleServicio.UpdatelDetalleFacturaAsync(detalle);
                }
                

                if (valor != null)
                {
                    return query;
                }
                throw new Exception("No se editaron los cambios en la factura");
            }
        }
    }
}
