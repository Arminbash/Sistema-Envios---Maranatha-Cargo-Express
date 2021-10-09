using _5._1.MCargoExpress.CRUD.Commands._TipoPersona;
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
        /// <returns>UsuarioDto Validado</returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/CreateTipoPersona
        [HttpPost("CreateTipoPersona")]
        public async Task<ActionResult<Unit>> CreateTipoPersona(CreateTipoPersona.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
    }
}
