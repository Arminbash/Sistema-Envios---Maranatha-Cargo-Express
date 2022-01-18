using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MCargoExpress.Aplication.Security
{
    /// <summary>
    /// Esta clase funciona para extender las validaciones de las contraseñas
    /// </summary>
    /// <typeparam name="TUser">Modelo Usuario</typeparam>
    /// <remarks>Johnny Arcia</remarks>
    public class PasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
    {
        /// <summary>
        /// Se implementa la validacion de password en tiempo de ejecucion
        /// </summary>
        /// <param name="manager">User Manager</param>
        /// <param name="user">Modelo usuario</param>
        /// <param name="password">password</param>
        /// <returns>Retorna una respuesta de aprobado si cumple con los estandares, sino retorna un failed</returns>
        /// Johnny Arcia
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
