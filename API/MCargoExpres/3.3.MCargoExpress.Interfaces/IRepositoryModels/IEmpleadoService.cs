using _3._1.MCargoExpress.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.IRepositoryModels
{
    /// <summary>
    /// Interfaz con metodos para Empleado
    /// </summary>
    /// Francisco Rios
    public interface IEmpleadoService
    {
        /// <summary>
        /// Agrega una nuevo Empleado
        /// </summary>
        /// <param name="Empleado">Empleado</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<EmpleadoDto> AddEmpledoAsync(EmpleadoDto empleadoDto);
        /// <summary>
        /// Actualiza a un Empleado
        /// </summary>
        /// <param name="empleado">Persona</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<EmpleadoDto> UpdateEmpleadoAsync(EmpleadoDto empleado);
        /// <summary>
        /// Obtiene todos  laos Empleados
        /// </summary>
        /// <returns>Obtiene todos los empleados</returns>
        /// Francisco Rios
        Task<IReadOnlyList<EmpleadoDto>> GetAllEmpleadoAsync();
        /// <summary>
        /// Obtiene un empleado por Id
        /// </summary>
        /// <param name="IdEmpleado">IdEmpleado</param>
        /// <returns>Retorna un Empleado</returns>
        /// Francisco Rios
        Task<EmpleadoDto> GetEmpeladoPorIdAsync(int IdEmpleado);
    }
}
