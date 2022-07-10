using _3._1.MCargoExpress.Dtos;
using _3._1.MCargoExpress.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.IRepositoryModels
{

    /// <summary>
    /// Interfaz con metodos para factura
    /// </summary>
    /// Eddy Vargas
    public interface IFacturaService
    {
        /// <summary>
        /// Agrega una nueva factura
        /// </summary>
        /// <param name="Factura">Factura</param>
        /// <returns></returns>
        /// Eddy Vargas
        
        Task<FacturaDto> AddFacturaAsync(FacturaDto facturaDto);


        /// <summary>
        /// Actualiza la factura
        /// </summary>
        /// <param name="Factura">Factura</param>
        /// <returns></returns>
        /// Eddy Vargas
        Task<FacturaDto> UpdateFacturaAsync(FacturaDto facturaDto);

        /// <summary>
        /// Obtiene todas las factura creadas
        /// </summary>
        /// <param name="Factura">Obtiene todas las facturas creadas</param>
        /// <returns></returns>
        /// Eddy Vargas

        Task<IReadOnlyList<FacturaDto>> GetAllFacturaAsync();


        /// <summary>
        /// Obtiene una factura por Id
        /// </summary>
        /// <param name="Factura">FacturaId</param>
        /// <returns></returns>
        /// Eddy Vargas
        /// 
        Task<FacturaDto> GetFacturaPorIdAsync(int FacturaId);


        /// <summary>
        /// Obtiene la lista de facturas paginado
        /// </summary>
        /// <param name="pagination">Objeto con los datos de paginacion</param>
        /// <returns>Retorna las facturas  paginadas</returns>
        /// Eddy Vargas
        Task<PaginationRequestBase<FacturaDto>> GetFacturaPaginadoAsync(PaginationDto pagination);
    }
}
