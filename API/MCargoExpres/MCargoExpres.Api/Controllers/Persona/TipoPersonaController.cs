using _3._1.MCargoExpress.Dtos;
using _3._1.MCargoExpress.Dtos.Base;
using _5._1.MCargoExpress.CRUD.Commands._TipoPersona;
using _5._2.MCargoExpress.CRUD.Querys._QTipoPersona;
using _5._2.MCargoExpress.CRUD.Querys.TipoPersona;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Controllers.Persona
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de tipo persona
    /// </summary>
    /// Francisco Rios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoPersonaController : ControllerBaseMediator
    {
        /// <summary>
        /// EndPoint encargado de crear un nuevo tipo persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/CreateTipoPersona
        [HttpPost("CreateTipoPersona")]
        public async Task<ActionResult<TipoPersonaDto>> CreateTipoPersona(CreateTipoPersona.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de Editar un tipo de persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/UpdatetipoPersona
        [HttpPut("UpdatetipoPersona")]
        public async Task<ActionResult<TipoPersonaDto>> UpdateTipoPersona(UpdateTipoPersona.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de listar Tipo Persona
        /// </summary>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/ObtenerTipoPersona
        [HttpGet("ObtenerTipoPersona")]
        public async Task<ActionResult<List<TipoPersonaDto>>> GetTipoPersona()
        {
            return await mediator.Send(new ObtenerTipoPersona.Ejecuta());
        }
        /// <summary>
        /// EndPoint encargado de buscar un Tipo Persona por Id
        /// </summary>
        /// <param name="id">Id del tipo persona</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/ObtenerTipoPersona/Id
        [HttpGet("ObtenerTipoPersona/{id}")]
        public async Task<ActionResult<TipoPersonaDto>> GetTipoPersonaXId(int id)
        {
            return await mediator.Send(new ObtenerTipoPersonaXId.Ejecuta {Id= id});
        }
        /// <summary>
        /// EndPoint que obtiene los tipos de personas paginados
        /// </summary>
        /// <param name="pagination">Objeto con datos de paginación</param>
        /// <returns></returns>
        /// <remarks>Johnny Arcia</remarks>
        /// /api/TipoPersona/ObtenerTipoPersonaPaginado
        [HttpPost("ObtenerTipoPersonaPaginado")]
        public async Task<ActionResult<PaginationRequestBase<TipoPersonaDto>>> GetTipoPersonaPaginado(PaginationDto pagination)
        {
            return await mediator.Send(new ObtenerTipoPersonaPaginado.Ejecuta { pagination= pagination});
        }

    }
}
