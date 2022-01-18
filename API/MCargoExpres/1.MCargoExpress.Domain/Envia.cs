using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MCargoExpress.Domain
{
    /// <summary>
    /// Modelo de persona
    /// </summary>
    /// Francisco Rios
    public class Envia:ClaseBase
    {

        /// <summary>
        /// clave foranea del cliente
        /// </summary>
        [ForeignKey("Cliente")]
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
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<Cotizacion> Cotizacion { get; set; }


    }
}
