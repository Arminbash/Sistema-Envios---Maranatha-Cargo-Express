using _3._1.MCargoExpress.Dtos;
using _5._1.MCargoExpress.CRUD.Commands.TipoPersona.Empleado;
using _5._2.MCargoExpress.CRUD.Querys._TipoPersona.Empleado;
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
    public class EmpleadoController : ControllerBaseMediator
    {
        /// <summary>
        /// EndPoint encargado de crear un Empelado
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/CreateEmpleado
        [HttpPost("CreateEmpleado")]
        public async Task<ActionResult<Unit>> CreateTipoPersona(CreateEmpleado.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de un Empleado
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Empleado/updateEmpleado
        [HttpPut("UpdateEmpleado")]
        public async Task<ActionResult<Unit>> UpdateTipoPersona(UpdateEmpleado.Ejecuta data)
        {
            return await mediator.Send(data);
        }
        /// <summary>
        /// EndPoint encargado de listar los Empleados
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Empleado/ObtenerPersona
        [HttpGet("ObtenerEmpleado")]
        public async Task<ActionResult<List<EmpleadoDto>>> GetPersona()
        {
            return await mediator.Send(new ObtenerEmpleado.Ejecuta());
        }
        /// <summary>
        /// EndPoint encargado de buscar un Empleado por Id
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Empleado/ObtenerEmpleado
        [HttpGet("ObtenerEmpleado/{id}")]
        public async Task<ActionResult<EmpleadoDto>> GetPersonaXId(int id)
        {
            return await mediator.Send(new ObtenerEmpleadoPorId.Ejecuta { Id = id });


        }
    }
}
