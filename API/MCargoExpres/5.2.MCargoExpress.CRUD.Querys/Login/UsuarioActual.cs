using _1.MCargoExpress.Domain;
using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._2.MCargoExpress.CRUD.Querys.Login
{
    /// <summary>
    /// Mediador que retorna el usuario actual
    /// </summary>
    /// Johnny Arcia
    public class UsuarioActual
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Johnny Arcia
        public class Ejecutar : IRequest<UsuarioDto> { }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Johnny Arcia
        public class Manejador : IRequestHandler<Ejecutar, UsuarioDto>
        {
            #region "Variables Globales"
            private readonly IUsuarioHelper _usuarioSesion;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            #endregion
            //// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="usuarioSesion">Interfaz Usuario helper</param>
            /// <param name="userManager">User Manager</param>
            /// <param name="jwtGenerador">Interfaz que genera Tokens</param>
            /// Johnny Arcia
            public Manejador(IUsuarioHelper usuarioSesion, UserManager<Usuario> userManager, IJwtGenerador jwtGenerador)
            {
                _usuarioSesion = usuarioSesion;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>El usuario Dto logeado</returns>
            /// Johnny Arcia
            public async Task<UsuarioDto> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

                var resultadoRoles = await _userManager.GetRolesAsync(usuario);
                var listaRoles = new List<string>(resultadoRoles);

                return new UsuarioDto
                {
                    NombreCompleto = usuario.NombreCompleto,
                    UserName = usuario.UserName,
                    Token = _jwtGenerador.CrearToken(usuario, listaRoles),
                    Imagen = null,
                    Email = usuario.Email
                };
            }
        }
    }
}
