using _5._1.MCargoExpress.CRUD.Commands.TipoPersonaM;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Controllers.TipoPersona
{
    [Authorize(Roles = "Admin")]
    public class TipoPersonaController : ControllerBaseMediator
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateTipoPersona(_5._1.MCargoExpress.CRUD.Commands.TipoPersonaM.CreateTipoPersona.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
    }
}
