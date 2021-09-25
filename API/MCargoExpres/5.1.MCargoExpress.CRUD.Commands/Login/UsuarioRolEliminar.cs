using _1.MCargoExpress.Domain;
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
    /// Mediador Eliminar Rol de Usuario
    /// </summary>
    /// Johnny Arcia
    public class UsuarioRolEliminar
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Johnny Arcia
        public class Ejecuta : IRequest
        {
            public string userName { get; set; }
            public string rolName { get; set; }
        }
        /// <summary>
        /// Fluent Validation
        /// </summary>
        /// Johnny Arcia
        public class ValidarEjecuta : AbstractValidator<Ejecuta>
        {
            public ValidarEjecuta()
            {
                RuleFor(x => x.userName).NotEmpty();
                RuleFor(x => x.rolName).NotEmpty();
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Johnny Arcia
        public class Manejador : IRequestHandler<Ejecuta>
        {
            #region "Variables Globales"
            private readonly UserManager<Usuario> userManager;
            private readonly RoleManager<IdentityRole> roleManager;
            #endregion
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_userManager">User Manager</param>
            /// <param name="_roleManager">Role Manager</param>
            /// Johnny Arcia
            public Manejador(UserManager<Usuario> _userManager, RoleManager<IdentityRole> _roleManager)
            {
                userManager = _userManager;
                roleManager = _roleManager;
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
                var role = await roleManager.FindByNameAsync(request.rolName);
                if (role == null)
                {
                    throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No se encontro el Rol" });
                }
                var usuarioIden = await userManager.FindByNameAsync(request.userName);
                if (usuarioIden == null)
                {
                    throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No se encontro el Usuario" });
                }
                var result = await userManager.RemoveFromRoleAsync(usuarioIden, request.rolName);
                if (result.Succeeded)
                {
                    return Unit.Value;
                }
                throw new Exception("No se logro eliminar el rol al usuario");
            }
        }
    }
}
