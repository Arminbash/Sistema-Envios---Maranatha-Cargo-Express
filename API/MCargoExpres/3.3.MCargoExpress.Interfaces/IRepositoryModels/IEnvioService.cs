using _3._1.MCargoExpress.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.IRepositoryModels
{
    /// <summary>
    /// Interfaz con metodos para envio
    /// </summary>
    /// Eddy Vargas
    public interface IEnvioService
    {
        /// <summary>
        /// Agrega un nuevo envio
        /// </summary>
        /// <param name="envio">Envio</param>
        /// <returns></returns>
        /// Eddy Vargas

        Task<EnvioDto> AddEnvioAsync(EnvioDto envioDto);


        /// <summary>
        /// Actualiza el envio
        /// </summary>
        /// <param name="envio">Envio</param>
        /// <returns></returns>
        /// Eddy Vargas
        Task<EnvioDto> UpdateEnvioAsync(EnvioDto envioDto);

        /// <summary>
        /// Obtiene todos los envios creados
        /// </summary>
        /// <param name="Envio">Obtiene todos los envios creados</param>
        /// <returns></returns>
        /// Eddy Vargas

        Task<IReadOnlyList<EnvioDto>> GetAllEnvioAsync();


        /// <summary>
        /// Obtiene un envio por Id
        /// </summary>
        /// <param name="Envio">EnvioId</param>
        /// <returns></returns>
        /// Eddy Vargas
        /// 
        Task<EnvioDto> GetEnvioPorIdAsync(int EnvioId);
    }
}
