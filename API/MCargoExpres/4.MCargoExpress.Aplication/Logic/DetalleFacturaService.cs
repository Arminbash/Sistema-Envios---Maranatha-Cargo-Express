using _1.MCargoExpress.Domain;
using _2._1.MCargoExpress.Persistence.Connection;
using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MCargoExpress.Aplication.Logic
{
    /// <summary>
    /// Implementacion de la interfaz de servicios para detalle de factura 
    /// </summary>
    /// Eddy Vargas
    public class DetalleFacturaService : IDetalleFacturaService
    {

        private IMapper mapper;

        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public DetalleFacturaService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        /// <summary>
        /// Agrega un nuevo detalle de factura
        /// </summary>
        /// <param name="DetalleFactura">Detalle de Factura</param>
        /// <returns>Factura</returns>
        /// Eddy Vargas
        public async Task<DetalleFacturaDto> AddDetalleFacturaAsync(DetalleFacturaDto detalleDto)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<DetalleFactura>();
                DetalleFactura newDetalle = new DetalleFactura();
                mapper.Map(detalleDto, newDetalle);
                repository.AddEntity(newDetalle);
                await _unitOfWork.Complete();

                return detalleDto;

            }
        }

        public Task<IReadOnlyList<DetalleFacturaDto>> GetAllDetalleFacturaAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtenemos una lista de detalles de facturas por facturaid
        /// </summary>
        /// <param name="DetalleFactura">Detalle de Factura</param>
        /// <returns>Factura</returns>
        /// Eddy Vargas

        public async Task<DetalleFacturaDto> GetlDetalleFacturaPorIdAsync(int DetalleId)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<DetalleFactura>(x => x.FacturaId == DetalleId);
                var detalle = await _UnitOfWork.Repository<DetalleFactura>().GetByIdWithSpec(query);

                return mapper.Map<DetalleFactura, DetalleFacturaDto>(detalle);
            }
        }


        /// <summary>
        /// Metodo para editar el detalle de la fcatura seleccionada
        /// </summary>
        /// <param name="DetalleFactura">Detalle de Factura</param>
        /// <returns>Factura</returns>
        /// Eddy Vargas
        public async Task<DetalleFacturaDto> UpdatelDetalleFacturaAsync(DetalleFacturaDto detalleDto)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _UnitOfWork.Repository<DetalleFactura>();
                DetalleFactura newDetalle = new DetalleFactura();
                mapper.Map(detalleDto, newDetalle);
                repository.UpdateEntity(newDetalle);
                await _UnitOfWork.Complete();

                return detalleDto;
            }
        }
    }
}
