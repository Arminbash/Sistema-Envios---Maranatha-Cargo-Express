using _3._1.MCargoExpress.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.IRepositoryModels
{
    /// <summary>
    /// Interfaz con metodos para Cliente
    /// </summary>
    /// Francisco Rios
    public interface IClienteService
    {
        /// <summary>
        /// Agrega una nuevo Cliente
        /// </summary>
        /// <param name="Cliente">Cliente</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<ClienteDto> AddClienteAsync(ClienteDto clienteDto);
        /// <summary>
        /// Actualiza a un Cliente
        /// </summary>
        /// <param name="cliente">Cliente</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<ClienteDto> UpdateClienteAsync(ClienteDto cliente);
        /// <summary>
        /// Obtiene todos  los clientes
        /// </summary>
        /// <returns>Obtiene todos los clientes</returns>
        /// Francisco Rios
        Task<IReadOnlyList<ClienteDto>> GetAllClientesAsync();
        /// <summary>
        /// Obtiene un Cliente por Id
        /// </summary>
        /// <param name="IdCliente">IdCliente</param>
        /// <returns>Retorna un Cliente</returns>
        /// Francisco Rios
        Task<ClienteDto> GetClientePorIdAsync(int IdCliente);
    }
}
