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
    /// Implementacion de la interfaz de servicios para  Persona
    /// </summary>
    /// Francisco Rios
    public class PersonaService : IPersonaService
    {
        private IMapper _mapper;
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public PersonaService()
        {

        }
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public PersonaService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Agrega una nueva persona
        /// </summary>
        /// <param name="Persona">Persona</param>
        /// <returns>tipo persona</returns>
        /// Francisco Rios
        public async Task<PersonaDto> AddPersonaAsync(PersonaDto persona)
        {
            using ( var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _UnitOfWork.Repository<Persona>();
                Persona newPersona = new Persona();
                _mapper.Map(persona,newPersona);
                repository.AddEntity(newPersona);
                await _UnitOfWork.Complete();
                return persona;
            }
        }
        /// <summary>
        /// Obtiene todas las persona
        /// </summary>
        /// <returns>Obtiene todas las persona</returns>
        /// Francisco Rios
        public async Task<IReadOnlyList<PersonaDto>> GetAllTipoPersonaAsync()
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var listPersona = await _unitOfWork.Repository<Persona>().GetAllAsync();
                return _mapper.Map<List<Persona>, List<PersonaDto>>(listPersona.ToList());
            }
        }
        /// <summary>
        /// Obtiene una persona por Id
        /// </summary>
        /// <param name="IdPersona">IdPersona</param>
        /// <returns>Retorna una persona</returns>
        /// Johnny Arcia
        public async Task<PersonaDto> GetPersonaPorIdAsync(int IdPersona)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<Persona>(x => x.Id == IdPersona);
                var persona = await _UnitOfWork.Repository<Persona>().GetByIdWithSpec(query);
                return _mapper.Map<Persona, PersonaDto>(persona);
            }
        }
        /// <summary>
        /// Actualiza una persona por Id
        /// </summary>
        /// <param name="Id">Id Persona/param>
        /// <returns></returns>
        /// Francisco Rios
        public async Task<PersonaDto> UpdatePersonaAsync(PersonaDto persona)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repositoty = _UnitOfWork.Repository<Persona>();
                Persona newPersona = new Persona();
                _mapper.Map(persona,newPersona);
                repositoty.UpdateEntity(newPersona);
                await _UnitOfWork.Complete();
                return persona;
            }
        }
    }
}
