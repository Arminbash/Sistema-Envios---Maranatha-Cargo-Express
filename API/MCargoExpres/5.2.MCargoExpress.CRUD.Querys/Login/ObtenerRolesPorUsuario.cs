using _1.MCargoExpress.Domain;
using _4.MCargoExpress.Aplication.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys.Login
{
    /// <summary>
    /// Mediador Obtiene todos los roles del usuario
    /// </summary>
    /// Johnny Arcia
    public class ObtenerRolesPorUsuario
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Johnny Arcia
        public class Ejecuta : IRequest<List<String>>
        {
            public string userName { get; set; }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Johnny Arcia
        public class Manejador : IRequestHandler<Ejecuta, List<string>>
        {
            #region "Variables Globales"
            private readonly UserManager<Usuario> userManager;
            private readonly RoleManager<IdentityRole> roleManager;
            #endregion
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="userManager">User Manager</param>
            /// <param name="_rolManager">Role Manager</param>
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
            /// <returns>Lista de nombres de roles</returns>
            /// Johnny Arcia
            public async Task<List<string>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuarioIden = await userManager.FindByNameAsync(request.userName);
                if (usuarioIden == null)
                {
                    throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el Usuario" });
                }

                var resultado = await userManager.GetRolesAsync(usuarioIden);
                return new List<string>(resultado);

            }
        }
    }
}
