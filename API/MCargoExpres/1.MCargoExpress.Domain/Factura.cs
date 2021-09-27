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
    public class Factura:ClaseBase
    {

        /// <summary>
        /// clave foranea del Envia
        /// </summary>
         [ForeignKey("Envia")]
        public int EnviaId { get; set; }

        /// <summary>
        /// clave foranea del Recibe
        /// </summary>
        [ForeignKey("Recibe")]
        public int RecibeId { get; set; }
        /// <summary>
        ///Fecha de la Factura
        /// </summary>
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// Tipo Moneda
        /// </summary>
        public string TipoMoneda { get; set; }
        ///<summary>
        /// Tipo Pago
        /// </summary>
        public string TipoPago { get; set; }
        ///<summary>
        /// Observacion
        /// </summary>
        public string Observacion { get; set; }
        /// <summary>
        /// Tasa Cambio
        /// </summary>
        public int TasaCambio { get; set; }
        /// <summary>
        /// propiedad de navegacion de Recive
        /// </summary>
      
        public virtual Recibe Recibe { get; set; }
        /// <summary>
        /// propiedad de navegacion de Envia
        /// </summary>
       
        public virtual Envia Envia { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
       
    }
}
