using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces.Security
{
    /// <summary>
    /// Interfaz encargada de controlar las sesiones del usuario
    /// </summary>
    /// Johnny Arcia
    public interface IUsuarioHelper
    {
        /// <summary>
        /// Obtiene el nombre del usuario logeado
        /// </summary>
        /// <returns>Nombre del usuario</returns>
        /// Johnny Arcia
        String ObtenerUsuarioSesion();
    }
}
