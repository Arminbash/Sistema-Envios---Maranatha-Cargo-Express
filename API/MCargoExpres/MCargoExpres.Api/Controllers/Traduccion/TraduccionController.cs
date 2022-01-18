using _3._1.MCargoExpress.Dtos;
using _5._1.MCargoExpress.CRUD.Commands.Traducciones;
using _5._2.MCargoExpress.CRUD.Querys.Traduccion;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Controllers.Traduccion
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de traduciones
    /// </summary>
    /// Francisco Rios
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TraduccionController : ControllerBaseMediator
    {
        /// <summary>
        /// EndPoint encargado de crear un nueva traduccion
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Traduccion/CrearTraduccion
        [HttpPost("CrearTraduccion")]
        public async Task<ActionResult<Unit>> CreateTipoPersona(CreateTraduccion.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
       
        /// <summary>
        /// EndPoint encargado de lista todas las traducciones
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/ObtenerTraducciones
        [HttpGet("ObtenerTraducciones")]
        public async Task<ActionResult<List<TraduccionDto>>> GetTraducciones()
        {
            return await mediator.Send(new ObtenerTraduccion.Ejecuta());
        }
        /// <summary>
        /// EndPoint encargado de buscar un Traduccion por Llave y lang
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/ObtenerTraduccionesPorLlave/Llave/Lang
        [HttpGet("ObtenerTipoPersona/{llave}/{lang}")]
        public async Task<ActionResult<TraduccionDto>> GetTraduccionXClave(string llave,string lang)
        {
            return await mediator.Send(new ObtenerTraduccionXClave.Ejecuta { Llave = llave,Lang=lang });
        }
    }
}
