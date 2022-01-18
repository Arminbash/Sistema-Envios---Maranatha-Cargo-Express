using _3._1.MCargoExpress.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.IRepositoryModels
{
    /// <summary>
    /// Interfaz con metodos para traduccion
    /// </summary>
    /// Johnny Arcia
    public interface ITraduccionService
    {
        /// <summary>
        /// Agrega una nueva traduccion
        /// </summary>
        /// <param name="traduccion">Traduccion Dto</param>
        /// <returns>Traduccion con Id</returns>
        /// Johnny Arcia
        Task<TraduccionDto> AddTraduccionAsync(TraduccionDto traduccion);
        /// <summary>
        /// Obtiene todas las traducciones en todos los lenguajes
        /// </summary>
        /// <returns>Obtiene todas las traducciones</returns>
        /// Johnny Arcia
        Task<IReadOnlyList<TraduccionDto>> GetAllTraduccionesAsync();
        /// <summary>
        /// Obtiene la traduccion de la clave
        /// </summary>
        /// <param name="clave">Clave de la traduccion</param>
        /// <returns>Retorna la traduccion que contienen la clave</returns>
        /// Johnny Arcia
        Task<TraduccionDto> GetTraduccionPorClaveAsync(string llave, string lang);
    }
}
