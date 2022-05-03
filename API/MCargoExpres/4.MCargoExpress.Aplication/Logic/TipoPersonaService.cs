using _1.MCargoExpress.Domain;
using _2._1.MCargoExpress.Persistence.Connection;
using _3._1.MCargoExpress.Dtos;
using _3._1.MCargoExpress.Dtos.Base;
using _3._2.MCargoExpress.Enums;
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
        /// <returns>tipo persona</returns>
        /// Francisco Rios
        public async Task<TipoPersonaDto> AddTipoPersonaAsync(TipoPersonaDto tipoPersona)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<TipoPersona>();
                TipoPersona newTipoPersona = new TipoPersona();
                mapper.Map(tipoPersona,newTipoPersona);
                newTipoPersona.Estado = true;
                repository.AddEntity(newTipoPersona);
                await _unitOfWork.Complete();
                return tipoPersona;
            }
        }
        /// <summary>
        /// Obtiene todos los Tipo de persona
        /// </summary>
        /// <returns>Lista tipo de persona</returns>
        /// Francisco Rios
        public async Task<IReadOnlyList<TipoPersonaDto>> GetAllTipoPersonaAsync()
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var tipoPersona = await _unitOfWork.Repository<TipoPersona>().GetAllAsync();
                return mapper.Map<List<TipoPersona>, List<TipoPersonaDto>>(tipoPersona.ToList());
            }
        }
        /// <summary>
        /// Obtiene el tipo de persona por Id
        /// </summary>
        /// <param name="IdTipoPersona">Id Tipo Persona/param>
        /// <returns>Retorna la tipo de persona por Id</returns>
        /// Francisco Rios
        public async Task<TipoPersonaDto> GetTipoPersonaPorIdAsync(int IdTipoPersona)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<TipoPersona>(x => x.Id == IdTipoPersona);
                var tipoPersona = await _unitOfWork.Repository<TipoPersona>().GetByIdWithSpec(query);
                return mapper.Map<TipoPersona, TipoPersonaDto>(tipoPersona);
            }
        }
        /// <summary>
        /// Actualiza el tipo de persona
        /// </summary>
        /// <param name="tipoPersona">Objeto Tipo Persona/param>
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
        /// <summary>
        /// Obtiene la lista de tipo personas paginados
        /// </summary>
        /// <param name="pagination">Objeto con los datos de paginacion</param>
        /// <returns>Retorna los tipo persona paginados</returns>
        /// Johnny Arcia
        public async Task<PaginationRequestBase<TipoPersonaDto>> GetTipoPersonaPaginadoAsync(PaginationDto pagination)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<TipoPersona>(x => (pagination.generalSearch == null || x.Tipo.Contains(pagination.generalSearch)) && (pagination.Estado == null || x.Estado == pagination.Estado));
                var totalData = await _unitOfWork.Repository<TipoPersona>().CountAsync(query);

                if (pagination.sort == SortEnum.desc) query.AddOrderByDescending(x => x.Id);
                else query.AddOrderBy(x => x.Id);

                query.ApplyPaging(pagination.perpage * (pagination.page - 1), pagination.perpage);

                var listTipoPersona = await _unitOfWork.Repository<TipoPersona>().GetAllWithSpec(query);
                var request = new PaginationRequestBase<TipoPersonaDto>
                {
                    meta = new PaginationMetadataBase
                    {
                        page = pagination.page,
                        field = pagination.field,
                        pages = (totalData + pagination.perpage - 1) / pagination.perpage,
                        perpage = pagination.perpage,
                        sort = pagination.sort,
                        total = totalData
                    },
                    data = mapper.Map<List<TipoPersona>, List<TipoPersonaDto>>(listTipoPersona.ToList())
                };
                return request;
            }
        }

    }
}
