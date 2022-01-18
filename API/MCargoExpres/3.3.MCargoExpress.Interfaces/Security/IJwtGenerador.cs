using _1.MCargoExpress.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.Security
{
    /// <summary>
    /// Interfaz encargada de manipular los metodos del JWT
    /// </summary>
    /// Johnny Arcia
    public interface IJwtGenerador
    {
        /// <summary>
        /// Metodo encargado de crear token del usuario
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        /// <param name="roles">Lista de nombres de roles para el usuario</param>
        /// <returns>Token de conexion</returns>
        /// <remarks>Johnny Arcia</remarks>
        string CrearToken(Usuario usuario, List<string> roles);
    }
}
