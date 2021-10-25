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
    /// Interfaz con metodos para Persona
    /// </summary>
    /// Francisco Rios
    public interface IPersonaService
    {
        /// <summary>
        /// Agrega una nueva persona
        /// </summary>
        /// <param name="Persona">tipoPersona</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<PersonaDto> AddPersonaAsync(PersonaDto persona);
        /// <summary>
        /// Actualiza a un persona
        /// </summary>
        /// <param name="Persona">Persona</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<PersonaDto> UpdatePersonaAsync(PersonaDto persona);
        /// <summary>
        /// Obtiene todas  las Persona 
        /// </summary>
        /// <returns>Obtiene todas las persona</returns>
        /// Francisco Rios
        Task<IReadOnlyList<PersonaDto>> GetAllTipoPersonaAsync();
        /// <summary>
        /// Obtiene una  persona por Id
        /// </summary>
        /// <param name="IdPersona">IdTipoPersona</param>
        /// <returns>Retorna una persona</returns>
        /// Francisco Rios
        Task<PersonaDto> GetPersonaPorIdAsync(int IdPersona);

    }
}
