using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MCargoExpres.Api.Controllers
{
    /// <summary>
    /// Controller que inicializa los mediadores en los demas controllers
    /// </summary>
    /// Johnny Arcia
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerBaseMediator : ControllerBase
    {
        private IMediator _mediator;
        /// <summary>
        /// Mediador que se usa para llamar cualquier mediador en todos los controller
        /// </summary>
        protected IMediator mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}
