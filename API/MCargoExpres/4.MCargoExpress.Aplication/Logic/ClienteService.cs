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
    /// Implementacion de la interfaz de servicios para  Cliente
    /// </summary>
    /// Francisco Rios
    public class ClienteService : IClienteService
    {
        private IMapper mapper;
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public ClienteService()
        {
        }
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public ClienteService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        /// <summary>
        /// Agrega un nuevo Cliente
        /// </summary>
        /// <param name="Cliente">Cliente</param>
        /// <returns>Cliente</returns>
        /// Francisco Rios
        public async Task<ClienteDto> AddClienteAsync(ClienteDto clienteDto)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _UnitOfWork.Repository<Cliente>();
               Cliente newCliente = new Cliente();
                mapper.Map(clienteDto, newCliente);
                repository.AddEntity(newCliente);
                await _UnitOfWork.Complete();
                return clienteDto;
            }
        }
        /// <summary>
        /// Obtiene todas los Clientes
        /// </summary>
        /// <returns>Obtiene todas los Clientes</returns>
        /// Francisco Rios
        public async Task<IReadOnlyList<ClienteDto>> GetAllClientesAsync()
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var listCliente = await _UnitOfWork.Repository<Cliente>().GetAllAsync();
                return mapper.Map<List<Cliente>, List<ClienteDto>>(listCliente.ToList());

            }
        }
        /// <summary>
        /// Obtiene un Cliente por Id
        /// </summary>
        /// <param name="IdCliente">IdCliente</param>
        /// <returns>Retorna un Cliente</returns>
        /// Francisco Rios
        public async Task<ClienteDto> GetClientePorIdAsync(int IdCliente)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<Cliente>(x => x.Id == IdCliente);
                var cliente = await _UnitOfWork.Repository<Cliente>().GetByIdWithSpec(query);
                return mapper.Map<Cliente, ClienteDto>(cliente);
            }
        }
        /// <summary>
        /// Actualiza un Cliente por Id
        /// </summary>
        /// <param name="Id">IdCliente/param>
        /// <returns></returns>
        /// Francisco Rios
        public async Task<ClienteDto> UpdateClienteAsync(ClienteDto cliente)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _UnitOfWork.Repository<Cliente>();
                Cliente newCliente = new Cliente();
                mapper.Map(cliente, newCliente);
                repository.UpdateEntity(newCliente);
                await _UnitOfWork.Complete();
                return cliente;
            }
        }
        /// <summary>
        /// Obtiene la lista de clientes paginados
        /// </summary>
        /// <param name="pagination">Objeto con los datos de paginacion</param>
        /// <returns>Retorna los cliente paginados</returns>
        /// Francisco Rios 
        public async Task<PaginationRequestBase<ClienteDto>> GetClientePaginadoAsync(PaginationDto pagination)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<Cliente>(x => (pagination.generalSearch == null || x.Persona.PrimerNombre.Contains(pagination.generalSearch)) && (pagination.Estado == null || x.Estado == pagination.Estado));
                var totalData = await _unitOfWork.Repository<Cliente>().CountAsync(query);

                if (pagination.sort == SortEnum.desc) query.AddOrderByDescending(x => x.Id);
                else query.AddOrderBy(x => x.Id);

                query.ApplyPaging(pagination.perpage * (pagination.page - 1), pagination.perpage);

                var listTipoCliente =  _unitOfWork.Repository<Cliente>().ApplySpecification(query).Select(x => new ClienteDto
                {
                    Id = x.Id,
                    PersonaId = x.PersonaId,
                    TipoClienteId =x.TipoClienteId,
                    PrimerNombre  = x.Persona.PrimerNombre,
                    Estado= x.Estado

                });

                var request = new PaginationRequestBase<ClienteDto>
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
                    data = listTipoCliente.ToList()
                };
                return request;
            }
        }
    }
}
