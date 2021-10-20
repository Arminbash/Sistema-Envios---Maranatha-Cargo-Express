using _1.MCargoExpress.Domain;
using _3._1.MCargoExpress.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.IRepositoryModels
{
    /// <summary>
    /// Interfaz con metodos para TipoPersona
    /// </summary>
    /// Francisco Rios
    public interface ITipoPersonaService
    {
        /// <summary>
        /// Agrega una nueva tipo persona
        /// </summary>
        /// <param name="`tipoPersona">tipoPersona</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<TipoPersonaDto> AddTipoPersonaAsync(TipoPersonaDto tipoPersona);
        /// <summary>
        /// Actualiza el tipo Persona
        /// </summary>
        /// <param name="IdTipoPersona">tipoPersona</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<TipoPersonaDto> UpdateTipoPersonaAsync(TipoPersonaDto tipoPersona);
        /// <summary>
        /// Obtiene todas los tipos Persona en todos 
        /// </summary>
        /// <returns>Obtiene todas los tipos persona</returns>
        /// Francisco Rios
        Task<IReadOnlyList<TipoPersona>> GetAllTipoPersonaAsync();
        /// <summary>
        /// Obtiene el tipo de persona
        /// </summary>
        /// <param name="IdTipoPersona">IdTipoPersona</param>
        /// <returns>Retorna la traduccion que contienen la clave</returns>
        /// Francisco Rios
        Task<TipoPersona> GetTipoPersonaPorIdAsync(int IdTipoPersona);

    }
}
