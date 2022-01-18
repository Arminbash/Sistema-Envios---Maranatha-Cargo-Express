using _3._1.MCargoExpress.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.IRepositoryModels
{
    /// <summary>
    /// Interfaz con metodos para TipoCliente
    /// </summary>
    /// Francisco Rios
    public interface ITipoClienteService
    {
            /// <summary>
            /// Agrega una nueva tipo Cliente
            /// </summary>
            /// <param name="`tipoCliente">tipoCliente</param>
            /// <returns></returns>
            /// Francisco Rios
            Task<TipoClienteDto> AddTipoClienteAsync(TipoClienteDto tipoCliente);
            /// <summary>
            /// Actualiza el tipo Cliente
            /// </summary>
            /// <param name="IdTipoCliente">tipoCliente</param>
            /// <returns></returns>
            /// Francisco Rios
            Task<TipoClienteDto> UpdateTipoClienteAsync(TipoClienteDto tipoCliente);
            /// <summary>
            /// Obtiene todas los tipos Cliente en todos 
            /// </summary>
            /// <returns>Obtiene todas los tipos Cliente</returns>
            /// Francisco Rios
            Task<IReadOnlyList<TipoClienteDto>> GetAllTipoClienteAsync();
            /// <summary>
            /// Obtiene el tipo de Cliente
            /// </summary>
            /// <param name="IdTipoCliente">IdTipoCliente</param>
            /// <returns>Retorna la traduccion que contienen la clave</returns>
            /// Francisco Rios
            Task<TipoClienteDto> GetTipoClientePorIdAsync(int IdTipoCliente);
        }
    }

