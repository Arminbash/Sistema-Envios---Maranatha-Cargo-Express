using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MCargoExpress.Domain
{
    /// <summary>
    /// Modelo de  detalle cotizacion
    /// </summary>
    /// Francisco Rios
    public class DetalleCotizacion:ClaseBase
    {

        /// <summary>
        /// clave foranea de la cotizacion
        /// </summary>
         [ForeignKey("Cotizacion")]
        public int CotizacionId { get; set; }

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
        /// propiedad de navegacion de cotizacion
        /// </summary>
       
        public virtual Cotizacion Cotizacion { get; set; }
    }
}
