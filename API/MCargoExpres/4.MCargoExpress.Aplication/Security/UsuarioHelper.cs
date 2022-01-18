using _3._3.MCargoExpress.Interfaces.Security;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _4.MCargoExpress.Aplication.Security
{
    /// <summary>
    /// Implementacion de usuario helper encargada de controlar las sesiones del usuario
    /// </summary>
    /// Johnny Arcia
    public class UsuarioHelper : IUsuarioHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// Constructor base para injeccion de dependencias
        /// </summary>
        /// <param name="httpContextAccessor">Contexto de Identity</param>
        public UsuarioHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Obtiene el nombre del usuario logeado
        /// </summary>
        /// <returns>Nombre del usuario</returns>
        /// Johnny Arcia
        public string ObtenerUsuarioSesion()
        {
            var userName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }
    }
}
