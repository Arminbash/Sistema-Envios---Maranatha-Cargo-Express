using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MCargoExpress.Domain
{
    /// <summary>
    /// Modelo de factura
    /// </summary>
    /// Francisco Rios
    public class DetalleFactura:ClaseBase
    {

        /// <summary>
        /// clave foranea de la Factura
        /// </summary>
         [ForeignKey("Factura")]
        public int FacturaId { get; set; }
    
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        ///<summary>
        /// Rate
        /// </summary>
        public decimal Rate { get; set; }
        ///<summary>
        /// LBS
        /// </summary>
        public decimal LBS { get; set; }
        /// <summary>
        /// VOL
        /// </summary>
        public decimal VOL { get; set; }
        /// <summary>
        /// IVA
        /// </summary>
        public decimal IVA { get; set; }
        /// <summary>
        /// propieda de navegacion de factura
        /// </summary>

       

        public virtual Factura Factura { get; set; }
    }
}
