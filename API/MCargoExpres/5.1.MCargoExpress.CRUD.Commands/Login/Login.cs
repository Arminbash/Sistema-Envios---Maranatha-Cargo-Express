using _1.MCargoExpress.Domain;
using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.Security;
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
    /// Mediador Login
    /// </summary>
    /// Johnny Arcia
    public class Login
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        /// Johnny Arcia
        public class Ejecuta : IRequest<UsuarioDto>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        /// <summary>
        /// Fluent Validation
        /// </summary>
        /// Johnny Arcia
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        /// Johnny Arcia
        public class Manejador : IRequestHandler<Ejecuta, UsuarioDto>
        {
            #region "Variables Globales"
            private readonly UserManager<Usuario> _userManager;
            private readonly SignInManager<Usuario> _signInManager;
            private readonly IJwtGenerador _IJwtGenerador;
            #endregion
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="userManager">User Manager</param>
            /// <param name="signInManager">Login Manager</param>
            /// <param name="jwtGenerador">Interfaz que genera Tokens</param>
            /// Johnny Arcia
            public Manejador(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IJwtGenerador jwtGenerador)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _IJwtGenerador = jwtGenerador;
            }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Promesa de usuario Dto</returns>
            /// Johnny Arcia
            public async Task<UsuarioDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var _Usuario = await _userManager.FindByEmailAsync(request.Email);
                if (_Usuario == null)
                {
                    throw new ExceptionBase(HttpStatusCode.Unauthorized);
                }
                var resultado = await _signInManager.CheckPasswordSignInAsync(_Usuario, request.Password, false);
                var resultadoRoles = await _userManager.GetRolesAsync(_Usuario);
                var listaRoles = new List<string>(resultadoRoles);
                if (resultado.Succeeded)
                {
                    return new UsuarioDto
                    {
                        NombreCompleto = _Usuario.NombreCompleto,
                        Token = _IJwtGenerador.CrearToken(_Usuario, listaRoles),
                        UserName = _Usuario.UserName,
                        Email = _Usuario.Email,
                        Imagen = null
                    };
                }
                throw new ExceptionBase(HttpStatusCode.Unauthorized);
            }
        }
    }
}
