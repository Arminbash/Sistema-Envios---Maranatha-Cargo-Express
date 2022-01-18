using _1.MCargoExpress.Domain;
using _2._1.MCargoExpress.Persistence.Connection;
using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using _4.MCargoExpress.Aplication.Specifications;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MCargoExpress.Aplication.Logic
{
    /// <summary>
    /// Implementacion de la interfaz de servicios para traducciones
    /// </summary>
    /// Johnny Arcia
    public class TraduccionService : ITraduccionService
    {
        private IMapper mapper;
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public TraduccionService()
        {
        }
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public TraduccionService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        /// <summary>
        /// Agrega una nueva traduccion
        /// </summary>
        /// <param name="traduccion">Traduccion Dto</param>
        /// <returns>Traduccion con Id</returns>
        /// Johnny Arcia
        public async Task<TraduccionDto> AddTraduccionAsync(TraduccionDto traduccion)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<Traduccion>();
                Traduccion newTraduccion = new Traduccion();
                mapper.Map(traduccion, newTraduccion);
                repository.AddEntity(newTraduccion);
                await _unitOfWork.Complete();
                return traduccion;
            }
        }
        /// <summary>
        /// Obtiene todas las traducciones en todos los lenguajes
        /// </summary>
        /// <returns>Obtiene todas las traducciones</returns>
        /// Johnny Arcia
        public async Task<IReadOnlyList<TraduccionDto>> GetAllTraduccionesAsync()
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
              var traducciones = await _unitOfWork.Repository<Traduccion>().GetAllAsync();
              return  mapper.Map<List<Traduccion>, List<TraduccionDto>>(traducciones.ToList());
            }
        }
        /// <summary>
        /// Obtiene la traduccion de la clave
        /// </summary>
        /// <param name="clave">Clave de la traduccion</param>
        /// <returns>Retorna la traduccion que contienen la clave</returns>
        /// Johnny Arcia
        public async Task<TraduccionDto> GetTraduccionPorClaveAsync(string llave, string lang)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<Traduccion>(x => x.Llave == llave && x.Lang == lang);
                var traduccion = await _unitOfWork.Repository<Traduccion>().GetByIdWithSpec(query);
                return mapper.Map<Traduccion,TraduccionDto>(traduccion);
            }
        }
    }
}
