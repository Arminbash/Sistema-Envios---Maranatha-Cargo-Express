using _3._1.MCargoExpress.Dtos;
using _3._1.MCargoExpress.Dtos.Base;
using _5._1.MCargoExpress.CRUD.Commands.TipoPersona.TipoCliente;
using _5._1.MCargoExpress.CRUD.Commands.TipoPersona.TipoCliente.Cliente;
using _5._2.MCargoExpress.CRUD.Querys.TipoPersona.Cliente;
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
        // /api/Cliente/CreateCliente
        [HttpPost("CreateCliente")]
        public async Task<ActionResult<ClienteDto>> CreateCliente(CreateCliente.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de actualizar un cliente
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Cliente/updateCliente
        [HttpPut("UpdateCliente")]
        public async Task<ActionResult<ClienteDto>> UpdateCliente(UpdateCliente.Ejecuta data)
        {
            return await mediator.Send(data);
        }
        /// <summary>
        /// EndPoint encargado de listar los Clientes
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Cliente/ObtenerCliente
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
        // /api/Cliente/ObtenerCliente
        [HttpGet("ObtenerCliente/{id}")]
        public async Task<ActionResult<ClientViewModel>> GetClienteXId(int id)
        {
            return await mediator.Send(new ObtenerClientePorId.Ejecuta { Id = id });
        }
        /// <summary>
        /// EndPoint que obtiene los  clientes paginados
        /// </summary>
        /// <param name="pagination">Objeto con datos de paginación</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios/remarks>
        /// /api/Cliente/ObtenerClientePaginado
        [HttpPost("ObtenerClientePaginado")]
        public async Task<ActionResult<PaginationRequestBase<ClientViewModel>>> GetClientePaginado(PaginationDto pagination)
        {
            return await mediator.Send(new ObtenerClientePaginado.Ejecuta { pagination = pagination });
        }
    }
}
