using _1.MCargoExpress.Domain;
using _2._1.MCargoExpress.Persistence.Connection;
using _3._1.MCargoExpress.Dtos;
using _3._1.MCargoExpress.Dtos.Base;
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
    /// Implementacion de la interfaz de servicios para  factura
    /// </summary>
    /// Eddy Vargas
    public class FacturaService : IFacturaService
    {
        private IMapper mapper;
        

        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public FacturaService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        /// <summary>
        /// Agrega una nueva factura
        /// </summary>
        /// <param name="Factura">Factura</param>
        /// <returns>Factura</returns>
        /// Eddy Vargas
        public async Task<FacturaDto> AddFacturaAsync(FacturaDto facturaDto)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _UnitOfWork.Repository<Factura>();
               

                Factura newFactura = new Factura();
                mapper.Map(facturaDto, newFactura);

                
                repository.AddEntity(newFactura);
                await _UnitOfWork.Complete();


                facturaDto.Id = newFactura.Id;
                return facturaDto;
            }
        }

        public Task<IReadOnlyList<FacturaDto>> GetAllFacturaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaginationRequestBase<FacturaDto>> GetFacturaPaginadoAsync(PaginationDto pagination)
        {
            throw new NotImplementedException();
        }

        public async Task<FacturaDto> GetFacturaPorIdAsync(int FacturaId)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<Factura>(x => x.Id == FacturaId);
                var factura = await _UnitOfWork.Repository<Factura>().GetByIdWithSpec(query);
                return mapper.Map<Factura, FacturaDto>(factura);
            }
        }

        /// <summary>
        /// Actualiza una factura por Id
        /// </summary>
        /// <param name="Id">IdCliente/param>
        /// <returns></returns>
        /// Eddy Vargas
        public async Task<FacturaDto> UpdateFacturaAsync(FacturaDto facturaDto)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _UnitOfWork.Repository<Factura>();
                Factura newFactura = new Factura();
                mapper.Map(facturaDto, newFactura);
                repository.UpdateEntity(newFactura);
                await _UnitOfWork.Complete();
                return facturaDto;
            }
        }
    }
}
