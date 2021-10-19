using _1.MCargoExpress.Domain;
using _5._1.MCargoExpress.CRUD.Commands._TipoPersona;
using _5._2.MCargoExpress.CRUD.Querys._QTipoPersona;
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
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
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
        public async Task<ActionResult<Unit>> CreateTipoPersona(CreateTipoPersona.Ejecuta parametros)
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
        public async Task<ActionResult<Unit>> UpdateTipoPersona(UpdateTipoPersona.Ejecuta data)
        {
            return await mediator.Send(data);
        }
        /// <summary>
        /// EndPoint encargado de listar Tipo Persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/ObtenerTipoPersona
        [HttpGet("ObtenerTipoPersona")]
        public async Task<ActionResult<List<TipoPersona>>> GetTipoPersona()
        {
            return await mediator.Send(new ObtenerTipoPersona.Ejecuta());
        }
        /// <summary>
        /// EndPoint encargado de listar Tipo Persona
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/ObtenerTipoPersona
        [HttpGet("ObtenerTipoPersona/{id}")]
        public async Task<ActionResult<TipoPersona>> GetTipoPersonaXId(int id)
        {
            return await mediator.Send(new ObtenerTipoPersonaXId.Ejecuta {Id= id});
        }

    }
}
