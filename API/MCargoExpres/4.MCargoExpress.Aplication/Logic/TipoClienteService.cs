using _1.MCargoExpress.Domain;
using _2._1.MCargoExpress.Persistence.Connection;
using _3._1.MCargoExpress.Dtos;
using _3._1.MCargoExpress.Dtos.Base;
using _3._2.MCargoExpress.Enums;
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
    /// Implementacion de la interfaz de servicios para tipo Cliente
    /// </summary>
    /// Francisco Rios
    public class TipoClienteService :ITipoClienteService
    {
        private IMapper mapper;
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public TipoClienteService()
        {

        }
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public TipoClienteService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        /// <summary>
        /// Agrega un nuevo tipo Cliente
        /// </summary>
        /// <param name="tipoPersona">TipoCliente</param>
        /// <returns>tipo Cliente</returns>
        /// Francisco Rios
        public async Task<TipoClienteDto> AddTipoClienteAsync(TipoClienteDto tipoCliente)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<TipoCliente>();
                TipoCliente newTipoCliente = new TipoCliente();
                mapper.Map(tipoCliente, newTipoCliente);
                newTipoCliente.Estado = true;
                repository.AddEntity(newTipoCliente);
                await _unitOfWork.Complete();
                return tipoCliente;
            }
        }
        /// <summary>
        /// Obtiene todas los Tipo de Cliente
        /// </summary>
        /// <returns>Obtiene todas los tipo de Cliente</returns>
        /// Francisco Rios
        public async Task<IReadOnlyList<TipoClienteDto>> GetAllTipoClienteAsync()
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var tipocliente = await _unitOfWork.Repository<TipoCliente>().GetAllAsync();
                return mapper.Map<List<TipoCliente>, List<TipoClienteDto>>(tipocliente.ToList());
            }
        }
        /// <summary>
        /// Obtiene el tipo de Cliente por Id
        /// </summary>
        /// <param name="Id">Id Tipo cliente/param>
        /// <returns>Retorna la tipo de cliente por Id</returns>
        /// Francisco Rios
        public async Task<TipoClienteDto> GetTipoClientePorIdAsync(int IdTipoCliente)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<TipoCliente>(x => x.Id == IdTipoCliente);
                var tipoCliente = await _unitOfWork.Repository<TipoCliente>().GetByIdWithSpec(query);
                return mapper.Map<TipoCliente, TipoClienteDto>(tipoCliente);
            }
        }
        /// <summary>
        /// Actualiza el tipo de cliente por Id
        /// </summary>
        /// <param name="Id">Id Tipo Cliente/param>
        /// <returns></returns>
        /// Francisco Rios
        public async Task<TipoClienteDto> UpdateTipoClienteAsync(TipoClienteDto tipoCliente)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<TipoCliente>();
                TipoCliente newTipoCliente = new TipoCliente();
                mapper.Map(tipoCliente, newTipoCliente);
                repository.UpdateEntity(newTipoCliente);
                await _unitOfWork.Complete();
                return tipoCliente;
            }
        }
        /// <summary>
        /// Obtiene la lista de tipo clientes paginados
        /// </summary>
        /// <param name="pagination">Objeto con los datos de paginacion</param>
        /// <returns>Retorna los tipo cliente paginados</returns>
        /// Francisco Rios 
        public async Task<PaginationRequestBase<TipoClienteDto>> GetTipoClientePaginadoAsync(PaginationDto pagination)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<TipoCliente>(x => (pagination.generalSearch == null || x.Tipo.Contains(pagination.generalSearch)) && (pagination.Estado == null || x.Estado == pagination.Estado));
                var totalData = await _unitOfWork.Repository<TipoCliente>().CountAsync(query);

                if (pagination.sort == SortEnum.desc) query.AddOrderByDescending(x => x.Id);
                else query.AddOrderBy(x => x.Id);

                query.ApplyPaging(pagination.perpage * (pagination.page - 1), pagination.perpage);

                var listTipoCliente = await _unitOfWork.Repository<TipoCliente>().GetAllWithSpec(query);
                var request = new PaginationRequestBase<TipoClienteDto>
                {
                    meta = new PaginationMetadataBase
                    {
                        page = pagination.page,
                        field = pagination.field,
                        pages = (totalData + pagination.perpage - 1) / pagination.perpage,
                        perpage = pagination.perpage,
                        sort = pagination.sort,
                        total = totalData
                    },
                    data = mapper.Map<List<TipoCliente>, List<TipoClienteDto>>(listTipoCliente.ToList())
                };
                return request;
            }
        }
    }
}
