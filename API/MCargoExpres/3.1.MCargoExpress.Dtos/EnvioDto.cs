using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{
    /// <summary>
    /// Modelo de envio
    /// </summary>
    /// Eddy Vargas
    public class EnvioDto
    {

        /// <summary>
        /// Primary key
        /// </summary>

        public int Id { get; set; }
        /// <summary>
        /// clave foranea del cliente
        /// </summary>

        public int ClienteId { get; set; }
        /// <summary>
        ///Direccion
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// Cuidad
        /// </summary>
        public string Cuidad { get; set; }
        ///<summary>
        /// Estado
        /// </summary>
        public string Estados { get; set; }
        ///<summary>
        /// Codigo Postal
        /// </summary>
        public string CodigoPostal { get; set; }
        /// <summary>
        /// clave foranea del cliente
        /// </summary>
    }
}
