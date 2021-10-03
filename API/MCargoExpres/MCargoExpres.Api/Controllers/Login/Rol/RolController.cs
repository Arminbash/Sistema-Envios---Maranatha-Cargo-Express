using _5._1.MCargoExpress.CRUD.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Controllers.Login.Rol
{
    public class RolController : ControllerBaseMediator
    {
         [HttpPost("CreateRol")]
         public async Task<ActionResult<Unit>> CreateRol(RolNuevo.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
        [HttpDelete("DeleteRol")]
        public async Task<ActionResult<Unit>> DeleteRol(RolElimina.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }

    }
}
