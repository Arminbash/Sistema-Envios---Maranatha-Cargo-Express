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
    /// Implementacion de la interfaz de servicios para envio
    /// </summary>
    /// Eddy Vargas
    public class EnvioService : IEnvioService
    {
        private IMapper mapper;

        public EnvioService(IMapper _mapper)
        {
            mapper = _mapper;
        }



        public async Task<EnvioDto> AddEnvioAsync(EnvioDto envioDto)
        {
           using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<Envia>();
                Envia newEnvio = new Envia();
                mapper.Map(envioDto, newEnvio);
                newEnvio.Estado = true;
                repository.AddEntity(newEnvio);
                await _unitOfWork.Complete();

                return envioDto;
            }
        }

        public Task<IReadOnlyList<EnvioDto>> GetAllEnvioAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EnvioDto> GetEnvioPorIdAsync(int EnvioId)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Specifications.BaseSpecification<Envia>(x => x.Id == EnvioId);
                var envio = await _UnitOfWork.Repository<Envia>().GetByIdWithSpec(query);
                return mapper.Map<Envia, EnvioDto>(envio);
            }
        }

        public async Task<EnvioDto> UpdateEnvioAsync(EnvioDto envioDto)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _UnitOfWork.Repository<Envia>();
                Envia newEnvio = new Envia();
                mapper.Map(envioDto, newEnvio);
                repository.UpdateEntity(newEnvio);
                await _UnitOfWork.Complete();
                return envioDto;
            }
        }
    }
}
