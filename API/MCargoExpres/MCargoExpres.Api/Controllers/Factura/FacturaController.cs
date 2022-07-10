using _3._1.MCargoExpress.Dtos;
using _5._1.MCargoExpress.CRUD.Commands.Factura;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Controllers.Factura
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de Factura
    /// </summary>
    /// Francisco Rios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FacturaController : ControllerBaseMediator
    {
        /// <summary>
        /// EndPoint encargado de crear factura
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Eddy Vargas</remarks>
        // /api/Cliente/CreateFactura

        [HttpPost("CreateFactura")]
        public async Task<ActionResult<FacturaDto>>  CreateFactura(CreateFactura.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }
    }
}
