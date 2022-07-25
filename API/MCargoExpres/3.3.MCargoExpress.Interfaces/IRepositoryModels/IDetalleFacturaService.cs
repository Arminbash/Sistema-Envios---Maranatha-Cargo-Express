using _3._1.MCargoExpress.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.IRepositoryModels
{
    /// <summary>
    /// Interfaz con metodos para detalle de factura
    /// </summary>
    /// Eddy Vargas
    public interface IDetalleFacturaService
    {
        /// <summary>
        /// Agrega una nuevo detalle de factura
        /// </summary>
        /// <param name="DetalleFactura">detalle factura</param>
        /// <returns></returns>
        /// Eddy Vargas

        Task<DetalleFacturaDto> AddDetalleFacturaAsync(DetalleFacturaDto detalleDto);


        
        /// <summary>
        /// Actualiza el detalle de la factura
        /// </summary>
        /// <param name="DetalleFactura">detalle factura</param>
        /// <returns></returns>
        /// Eddy Vargas
        Task<DetalleFacturaDto> UpdatelDetalleFacturaAsync(DetalleFacturaDto detalleDto);

        /// <summary>
        /// Obtiene todas las factura creadas
        /// </summary>
        /// <param name="DetalleFactura">Obtiene todas las facturas creadas</param>
        /// <returns></returns>
        /// Eddy Vargas
        /// 
        Task<IReadOnlyList<DetalleFacturaDto>> GetAllDetalleFacturaAsync();

        /// <summary>
        /// Obtiene un detalle de factura por Id
        /// </summary>
        /// <param name="DetalleFactura">DetalleFacturaId</param>
        /// <returns></returns>
        /// Eddy Vargas
        /// 
        Task<DetalleFacturaDto> GetlDetalleFacturaPorIdAsync(int FacturaId);


        /// <summary>
        /// Obtiene los detalles de factura por Id
        /// </summary>
        /// <param name="DetalleFactura">DetalleFacturaId</param>
        /// <returns></returns>
        /// Eddy Vargas
        Task<List<DetalleFacturaDto>> GetlDetalleFacturaPorIdAsyncList(int FacturaId);

    }
}
