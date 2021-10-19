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
    /// Implementacion de la interfaz de servicios para tipo Persona
    /// </summary>
    /// Francisco Rios
    public class TipoPersonaService : ITipoPersonaService
    {
        private IMapper mapper;
        /// <summary>
        /// Constructor vacio
        /// </summary>
         public TipoPersonaService()
        {
           
        }
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public TipoPersonaService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        /// <summary>
        /// Agrega un nuevo tipo persona
        /// </summary>
        /// <param name="tipoPersona">TipoPersona</param>
        /// <returns>Traduccion con Id</returns>
        /// Francisco Rios
        public async Task<TipoPersonaDto> AddTipoPersonaAsync(TipoPersonaDto tipoPersona)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<TipoPersona>();
                TipoPersona newTipoPersona = new TipoPersona();
                mapper.Map(tipoPersona,newTipoPersona);
                repository.AddEntity(newTipoPersona);
                await _unitOfWork.Complete();
                return tipoPersona;
            }
        }
        /// <summary>
        /// Obtiene todas los Tipo de persona
        /// </summary>
        /// <returns>Obtiene todas los tipo de persona</returns>
        /// Francisco Rios
        public async Task<IReadOnlyList<TipoPersona>> GetAllTipoPersonaAsync()
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var tipoPersona = await _unitOfWork.Repository<TipoPersona>().GetAllAsync();
                return mapper.Map<List<TipoPersona>, List<TipoPersona>>(tipoPersona.ToList());
            }
        }
        /// <summary>
        /// Obtiene el tipo de persona por Id
        /// </summary>
        /// <param name="Id">Id Tipo Persona/param>
        /// <returns>Retorna la tipo de persona por Id</returns>
        /// Francisco Rios
        public async Task<TipoPersona> GetTipoPersonaPorIdAsync(int IdTipoPersona)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<TipoPersona>(x => x.Id == IdTipoPersona);
                var tipoPersona = await _unitOfWork.Repository<TipoPersona>().GetByIdWithSpec(query);
                return mapper.Map<TipoPersona, TipoPersona>(tipoPersona);
            }
        }
        /// <summary>
        /// Actualiza el tipo de persona por Id
        /// </summary>
        /// <param name="Id">Id Tipo Persona/param>
        /// <returns></returns>
        /// Francisco Rios
        public async Task<TipoPersonaDto> UpdateTipoPersonaAsync(TipoPersonaDto tipoPersona)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<TipoPersona>();
                TipoPersona newTipoPersona = new TipoPersona();
                mapper.Map(tipoPersona, newTipoPersona);
                repository.UpdateEntity(newTipoPersona);
                await _unitOfWork.Complete();
                return tipoPersona;
            }
        }
    }
}
