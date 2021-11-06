using _3._1.MCargoExpress.Dtos;
using _5._1.MCargoExpress.CRUD.Commands.TipoPersona.TipoCliente;
using _5._2.MCargoExpress.CRUD.Querys._TipoPersona_._TipoCliente;
using _5._2.MCargoExpress.CRUD.Querys.TipoPersona_.TipoCliente;
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
    /// Controller que se encarga de la manipulacion de tipo Cliente
    /// </summary>
    /// Francisco Rios
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TipoClienteController : ControllerBaseMediator
    {
        /// <summary>
        /// EndPoint encargado de crear un nuevo tipo cliente
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/TipoCliente/CreateTipoCliente
        [HttpPost("CreateTipoCliente")]
        public async Task<ActionResult<Unit>> CreateTipoCliente(CreateTipoCliente.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de Editar un tipo de Cliente
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/TipoCliente/Updatetipo/TipoCliente
        [HttpPut("UpdatetipoCliente")]
        public async Task<ActionResult<Unit>> UpdateTipoCliente(UpdateTipoCliente.Ejecuta data)
        {
            return await mediator.Send(data);
        }
        /// <summary>
        /// EndPoint encargado de listar Tipo Cliente
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/TipoCliente/ObtenerTipoCliente
        [HttpGet("ObtenerTipoCliente")]
        public async Task<ActionResult<List<TipoClienteDto>>> GetTipoCliente()
        {
            return await mediator.Send(new ObtenerTipoCliente.Ejecuta());
        }
        /// <summary>
        /// EndPoint encargado de buscar un Tipo Persona por Id
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/TipoCliente/ObtenerTipoPCliente/Id
        [HttpGet("ObtenerTipoPersona/{id}")]
        public async Task<ActionResult<TipoClienteDto>> GetTipoPersonaXId(int id)
        {
            return await mediator.Send(new ObtenerTipoClienteXId.Ejecuta { Id = id });
        }
    }
}
