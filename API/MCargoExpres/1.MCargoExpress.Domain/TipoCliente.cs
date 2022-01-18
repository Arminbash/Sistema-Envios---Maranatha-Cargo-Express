using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MCargoExpress.Domain
{
    /// <summary>
    /// Modelo de persona
    /// </summary>
    /// Francisco Rios
    public class TipoCliente:ClaseBase
    {
        /// <summary>
        /// Tipo de Cliente
        /// </summary>
        public string Tipo{ get; set; }

        /// <summary>
        /// clave forranea del  cliente
        /// </summary>
        public virtual ICollection<Cliente> Cliente { get; set; }

    }
}
