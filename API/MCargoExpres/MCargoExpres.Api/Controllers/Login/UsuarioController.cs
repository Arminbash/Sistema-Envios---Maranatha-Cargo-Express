using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using _5._1.MCargoExpress.CRUD.Commands.Login;
using _5._2.MCargoExpress.CRUD.Querys.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Controllers.Login
{
    /// <summary>
    /// Controller que se encarga de la manipulacion del usuario
    /// </summary>
    /// Johnny Arcia
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBaseMediator 
    {
        /// <summary>
        /// EndPoint encargado de los ingresos del usuario
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns>UsuarioDto Validado</returns>
        /// <remarks>Johnny Arcia</remarks>
        // /api/Usuario/login
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(_5._1.MCargoExpress.CRUD.Commands.Login.Login.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }

        /// <summary>
        /// EndPoint encargado de registrar nuevo usuario
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns>UsuarioDto Validado</returns>
        /// <remarks>Johnny Arcia</remarks>
        // /api/Usuario/Registrar
        [HttpPost("Registrar")]
        public async Task<ActionResult<UsuarioDto>> Registrar(Registrar.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }

        /// <summary>
        /// EndPoint encargado de devolver el usuario logeado
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns>UsuarioDto Validado</returns>
        /// <remarks>Johnny Arcia</remarks>
        // /api/Usuario
        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> DevolverUsuario()
        {
            return await mediator.Send(new UsuarioActual.Ejecutar());
        }
    }
}
