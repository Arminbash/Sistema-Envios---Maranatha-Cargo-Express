using _5._1.MCargoExpress.CRUD.Commands.Login;
using _5._2.MCargoExpress.CRUD.Querys.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Controllers.Login.Rol
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de los roles de usuario
    /// </summary>
    /// Francisco Rios
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class RolController : ControllerBaseMediator
    {
        /// <summary>
        /// EndPoint encargado de crear un nuevo rol
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns>UsuarioDto Validado</returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/CreateRol
        [HttpPost("CreateRol")]
         public async Task<ActionResult<Unit>> CreateRol(RolNuevo.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de eliminar un  rol
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns>UsuarioDto Validado</returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/DeleteRol
        [HttpDelete("DeleteRol")]
        public async Task<ActionResult<Unit>> DeleteRol(RolElimina.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de Obtener los roles de usuario
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns>Lista de roles</returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/GetRoles

        [HttpGet("GetRoles")]
        public async Task<ActionResult<List<IdentityRole>>> getRoles()
        {
            return await mediator.Send(new RolLista.Ejecuta());
        }
        /// <summary>
        /// EndPoint encargado de asignar un rol a usuarios
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns>UsuarioDto Validado</returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/CreateRolUsuario
        [HttpPost("CreateRolUsuario")]
        public async Task<ActionResult<Unit>> createRolUsuario(UsuarioRolAgregar.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de eliminar los roles que tiene asignado un usuario
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns>UsuarioDto Validado</returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/DeleteRolUsuario
        [HttpPost("DeleteRolUsuario")]
        public async Task<ActionResult<Unit>> deleteRolUsuario(UsuarioRolEliminar.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        /// <summary>
        /// EndPoint encargado de Obetener todos lo roles que tiene un usuario
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns>UsuarioDto Validado</returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/Rol/{UsurName}
        [HttpGet("{UserName}")]
        public async Task<ActionResult<List<string>>> GetRolUsuario( string UserName)
        {
            return await mediator.Send(new ObtenerRolesPorUsuario.Ejecuta { userName = UserName });
        }
    }
}
