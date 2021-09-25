using _4.MCargoExpress.Aplication.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._1.MCargoExpress.CRUD.Commands.Login
{
    /// <summary>
    /// Mediador Elminar Rol
    /// </summary>
    /// Johnny Arcia
    public class RolElimina
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Johnny Arcia
        public class Ejecuta : IRequest
        {
            public String Nombre { get; set; }
        }
        /// <summary>
        /// Fluent Validation
        /// </summary>
        /// Johnny Arcia
        public class ValidaEjecuta : AbstractValidator<Ejecuta>
        {
            public ValidaEjecuta()
            {
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Johnny Arcia
        public class Manejador : IRequestHandler<Ejecuta>
        {
            #region "Variables Globales"
            private readonly RoleManager<IdentityRole> rolManager;
            #endregion
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_rolManager">Role Manager</param>
            /// Johnny Arcia
            public Manejador(RoleManager<IdentityRole> _rolManager)
            {
                rolManager = _rolManager;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Tarea respuesta void de MediatR</returns>
            /// Johnny Arcia
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var rol = await rolManager.FindByNameAsync(request.Nombre);
                if (rol == null)
                {
                    throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "No existe Rol" });
                }
                var resultado = await rolManager.DeleteAsync(rol);
                if (resultado.Succeeded)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar el Rol");
            }
        }
    }
}
