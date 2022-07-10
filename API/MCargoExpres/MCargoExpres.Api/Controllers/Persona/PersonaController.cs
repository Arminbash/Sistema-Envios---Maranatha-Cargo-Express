using _3._1.MCargoExpress.Dtos;
using _5._1.MCargoExpress.CRUD.Commands._TipoPersona._Persona;
using _5._1.MCargoExpress.CRUD.Commands.TipoPersona.Persona;
using _5._2.MCargoExpress.CRUD.Querys._TipoPersona._Persona;
using _5._2.MCargoExpress.CRUD.Querys._TipoPersona._Personas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3._1.MCargoExpress.Dtos;
using _3._1.MCargoExpress.Dtos.Base;
using _5._2.MCargoExpress.CRUD.Querys.TipoPersona.Persona;

namespace MCargoExpres.Api.Controllers.Persona
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de persona
    /// </summary>
    /// Francisco Rios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonaController : ControllerBaseMediator
    {
        /// <summary>
        /// EndPoint encargado de crear a una persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/persona/CreatePersona
        [HttpPost("CreatePersona")]
        public async Task<ActionResult<PersonaDto>> CreatePersona(CreatePersona.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de una persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/persona/UpdatePersona
        [HttpPut("UpdatePersona")]
        public async Task<ActionResult<PersonaDto>> UpdatePersona(UpdatePersona.Ejecuta data)
        {
            return await mediator.Send(data);
        }
        /// <summary>
        /// EndPoint encargado de listar  Persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/persona/ObtenerPersona
        [HttpGet("ObtenerPersona")]
        public async Task<ActionResult<List<PersonaDto>>> GetPersona()
        {
            return await mediator.Send(new ObtenerPersona.Ejecuta());
        }
        /// <summary>
        /// EndPoint encargado de buscar una  Persona por Id
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/persona/ObtenerPersona
        [HttpGet("ObtenerPersona/{id}")]
        public async Task<ActionResult<PersonaDto>> GetPersonaXId(int id)
        {
            return await mediator.Send(new ObtenerPersonaXId.Ejecuta { Id = id });
        }
        /// <summary>
        /// EndPoint que obtiene los tipos de personas paginados
        /// </summary>
        /// <param name="pagination">Objeto con datos de paginación</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        /// /api/persona/ObtenerPersonaPaginado
        [HttpPost("ObtenerPersonaPaginado")]
        public async Task<ActionResult<PaginationRequestBase<PersonViewModel>>> GetPersonaPaginado(PaginationDto pagination)
        {
            return await mediator.Send(new ObtenerPersonaPaginado.Ejecuta { pagination = pagination });
        }
    }
}
