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
    }
}
