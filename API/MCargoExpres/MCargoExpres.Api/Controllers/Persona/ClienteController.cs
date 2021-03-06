using _3._1.MCargoExpress.Dtos;
using _5._1.MCargoExpress.CRUD.Commands.TipoPersona.TipoCliente;
using _5._1.MCargoExpress.CRUD.Commands.TipoPersona.TipoCliente.Cliente;
using _5._2.MCargoExpress.CRUD.Querys.TipoPersona2.Cliente;
using _5._2.MCargoExpress.CRUD.Querys.TipoPersona2.Empleado;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Controllers._Persona
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de Clientes
    /// </summary>
    /// Francisco Rios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBaseMediator
    {
        /// <summary>
        /// EndPoint encargado de crear un Empelado
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/CreateCliente
        [HttpPost("CreateCliente")]
        public async Task<ActionResult<Unit>> CreateCliente(CreateCliente.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de actualizar un cliente
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Empleado/updateCliente
        [HttpPut("UpdateCliente")]
        public async Task<ActionResult<Unit>> UpdateCliente(UpdateCliente.Ejecuta data)
        {
            return await mediator.Send(data);
        }
        /// <summary>
        /// EndPoint encargado de listar los Clientes
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Empleado/ObtenerCliente
        [HttpGet("ObtenerCliente")]
        public async Task<ActionResult<List<ClienteDto>>> GetCliente()
        {
            return await mediator.Send(new ObtenerCliente.Ejecuta());
        }
        /// <summary>
        /// EndPoint encargado de buscar un Cliente por Id
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Empleado/ObtenerCliente
        [HttpGet("ObtenerCliente/{id}")]
        public async Task<ActionResult<ClienteDto>> GetClienteXId(int id)
        {
            return await mediator.Send(new ObtenerClientePorId.Ejecuta { Id = id });


        }
    }
}
