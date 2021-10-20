using _5._1.MCargoExpress.CRUD.Commands._TipoPersona._Persona;
using _5._1.MCargoExpress.CRUD.Commands.TipoPersona.Persona;
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
        // /api/Rol/UpdatetipoPersona
        [HttpPut("UpdatePersona")]
        public async Task<ActionResult<Unit>> UpdateTipoPersona(UpdatePersona.Ejecuta data)
        {
            return await mediator.Send(data);
        }

    }
    }
