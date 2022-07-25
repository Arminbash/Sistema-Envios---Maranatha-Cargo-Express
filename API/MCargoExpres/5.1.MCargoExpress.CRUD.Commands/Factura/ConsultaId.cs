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

namespace _5._1.MCargoExpress.CRUD.Commands.Factura
{

    /// <summary>
    /// Mediador para obtener las factura y su detalle
    /// </summary>
    /// Eddy Vargas
    public class ConsultaId
    {

        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class GetFacturaById : IRequest<FacturaDto>
        {
            /// <summary>
            /// Primary key
            /// </summary>

            public int Id { get; set; }

          
        }

        public class Manejador : IRequestHandler<GetFacturaById, FacturaDto>
        {

            private readonly IFacturaService facturaService;

            private readonly IDetalleFacturaService detalleServicio;

            private readonly IEnvioService envioServicio;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_facturaServicio">Servicio de factura</param>
            /// Eddy Vargas
            public Manejador(IFacturaService _facturaService, IDetalleFacturaService _detalleFacturaService, IEnvioService _envioServicio)
            {
                facturaService = _facturaService;
                detalleServicio = _detalleFacturaService;
                envioServicio = _envioServicio;
                
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns></returns>
            /// Eddy Vargas

            public async Task<FacturaDto> Handle(GetFacturaById request, CancellationToken cancellationToken)
            {
                var GetInvoice = await facturaService.GetFacturaPorIdAsync(request.Id);
                var DataEnvio = await envioServicio.GetEnvioPorIdAsync(GetInvoice.EnviaId);
                FacturaDto factura;
                factura = new FacturaDto
                {
                    Id = GetInvoice.Id,
                    EnviaId = GetInvoice.EnviaId,
                    Direccion = DataEnvio.Direccion,
                    ClienteId = DataEnvio.ClienteId,
                    Ciudad = DataEnvio.Ciudad,
                    Estados = DataEnvio.Estados,
                    CodigoPostal = DataEnvio.CodigoPostal,
                    RecibeId = GetInvoice.RecibeId,
                    FechaIngreso = GetInvoice.FechaIngreso,
                    TipoMoneda = GetInvoice.TipoMoneda,
                    TipoPago = GetInvoice.TipoPago,
                    Observacion = GetInvoice.Observacion,
                    TasaCambio = GetInvoice.TasaCambio,
                    Estatus = GetInvoice.Estatus
                    
                };

                factura.DetalleFacturaDto = detalleServicio.GetlDetalleFacturaPorIdAsyncList(GetInvoice.Id).Result;

                



                if (GetInvoice == null && factura == null)
                {
                    throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "No se pudo encontrar la factura que quiere" });
                }
                return factura;
            }
        }
    }
}
