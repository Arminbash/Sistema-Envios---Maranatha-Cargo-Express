using _1.MCargoExpress.Domain;
using _2._1.MCargoExpress.Persistence.Connection;
using _2._2.MCargoExpress.Persistence.Settings;
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
    /// Implementacion de la interfaz de servicios para  Empleado
    /// </summary>
    /// Francisco Rios
    public class EmpleadoService: IEmpleadoService
    {
        private IMapper mapper;
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public EmpleadoService()
        {
        }
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public EmpleadoService (IMapper _mapper)
        {
            mapper = _mapper;
        }
        /// <summary>
        /// Agrega un nuevo empleado
        /// </summary>
        /// <param name="Empleado">Empleado</param>
        /// <returns>Empleado</returns>
        /// Francisco Rios
        public async Task<EmpleadoDto> AddEmpledoAsync(EmpleadoDto empleado)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _UnitOfWork.Repository<Empleado>();
                Empleado newempleado = new Empleado();
                mapper.Map(empleado,newempleado);
                repository.AddEntity(newempleado);
                 await _UnitOfWork.Complete();
                return empleado;
            }
        }
        /// <summary>
        /// Obtiene todas los Empleado
        /// </summary>
        /// <returns>Obtiene todas las persona</returns>
        /// Francisco Rios
        public async Task<IReadOnlyList<EmpleadoDto>> GetAllEmpleadoAsync()
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var listEmpleado = await _UnitOfWork.Repository<Empleado>().GetAllAsync();
                return mapper.Map<List<Empleado>, List<EmpleadoDto>>(listEmpleado.ToList());

            }
        }
        /// <summary>
        /// Obtiene un empleado por Id
        /// </summary>
        /// <param name="IdEmpleado">IdEmpleado</param>
        /// <returns>Retorna un Empleado</returns>
        /// Francisco Rios
        public async Task<EmpleadoDto> GetEmpeladoPorIdAsync(int IdEmpleado)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<Empleado>(x => x.Id == IdEmpleado);
                var empleado = await _UnitOfWork.Repository<Empleado>().GetByIdWithSpec(query);
                return mapper.Map<Empleado, EmpleadoDto>(empleado);
            }
        }
        /// <summary>
        /// Actualiza un Empleado por Id
        /// </summary>
        /// <param name="Id">IdEmpleado/param>
        /// <returns></returns>
        /// Francisco Rios
        public async Task<EmpleadoDto> UpdateEmpleadoAsync(EmpleadoDto empleado)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _UnitOfWork.Repository<Empleado>();
                Empleado newEmpleado = new Empleado();
                mapper.Map(empleado,newEmpleado);
                repository.UpdateEntity(newEmpleado);
                await _UnitOfWork.Complete();
                return  empleado;
            }
        }
    }
}
