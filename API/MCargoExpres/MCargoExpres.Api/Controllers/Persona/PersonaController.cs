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

namespace MCargoExpres.Api.Controllers.Persona
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de persona
    /// </summary>
    /// Francisco Rios
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PersonaController : ControllerBaseMediator
    {
        /// <summary>
        /// EndPoint encargado de crear a una persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/CreatePersona
        [HttpPost("CreatePersona")]
        public async Task<ActionResult<Unit>> CreateTipoPersona(CreatePersona.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de una persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/UpdatePersona
        [HttpPut("UpdatePersona")]
        public async Task<ActionResult<Unit>> UpdateTipoPersona(UpdatePersona.Ejecuta data)
        {
            return await mediator.Send(data);
        }
        /// <summary>
        /// EndPoint encargado de listar  Persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/ObtenerPersona
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
        // /api/Rol/ObtenerPersona
        [HttpGet("ObtenerPersona/{id}")]
        public async Task<ActionResult<PersonaDto>> GetPersonaXId(int id)
        {
            return await mediator.Send(new ObtenerPersonaXId.Ejecuta { Id = id });
        }
    }
}
