using _2._2.MCargoExpress.Persistence.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys.Login
{
    /// <summary>
    /// Mediador para lista de roles
    /// </summary>
    /// Johnny Arcia
    public class RolLista
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Johnny Arcia
        public class Ejecuta : IRequest<List<IdentityRole>>
        {
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Johnny Arcia
        public class Manejador : IRequestHandler<Ejecuta, List<IdentityRole>>
        {
            #region "Variables Globales"
            private readonly IConexion context;
            #endregion
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_context">Contexto Base</param>
            /// Johnny Arcia
            public Manejador(IConexion _context)
            {
                context = _context;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Lista de roles</returns>
            /// Johnny Arcia
            public async Task<List<IdentityRole>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var roles = await context.Roles.ToListAsync();

                return roles;
            }
        }
    }
}
