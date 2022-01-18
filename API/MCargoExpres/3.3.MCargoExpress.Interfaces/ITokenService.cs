using _1.MCargoExpress.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces
{
    /// <summary>
    /// Interfaz encargada del manejo de tokens
    /// </summary>
    /// Johnny Arcia
    public interface ITokenService
    {
        /// <summary>
        /// Implementacion encargado de crear nuevos tokens
        /// </summary>
        /// <param name="usuario">Entidad Usuario</param>
        /// <param name="roles">Roles del usuario</param>
        /// <returns>Nuevo Token</returns>
        string CreateToken(Usuario usuario, IList<string> roles);
    }
}
