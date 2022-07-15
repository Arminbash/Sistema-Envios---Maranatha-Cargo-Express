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
        // /api/Factura/CreateFactura

        [HttpPost("CreateFactura")]
        public async Task<ActionResult<Unit>>  CreateFactura(CreateFactura.Ejecuta parametros)
        {
            return await mediator.Send(parametros);
        }


        /// <summary>
        /// EndPoint encargado de actualizar un la factura
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Eddy vargas</remarks>
        // /api/Factura/UpdateFactura
        [HttpPut("UpdateFactura")]
        public async Task<ActionResult<Unit>> UpdateFactura(UpdateFactura.Ejecuta data)
        {
            return await mediator.Send(data);
        }



        /// <summary>
        /// EndPoint encargado de mostrar la factura y su detalle para editar
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Eddy vargas</remarks>
        // /api/Factura/GetFacturaEdit
        [HttpGet("{Id}")]
        public async Task<ActionResult<FacturaDto>> GetFacturaEdit(int id)
        {
            return await mediator.Send(new ConsultaId.GetFacturaById { Id = id});
        }
    }
}
