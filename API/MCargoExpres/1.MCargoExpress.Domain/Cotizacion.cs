using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MCargoExpress.Domain
{
    /// <summary>
    /// Modelo de cotizacion
    /// </summary>
    /// Francisco Rios
    public class Cotizacion:ClaseBase
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
        /// Propiedad de navegacion de Recibe
        /// </summary>
       
        public virtual Recibe Recibe { get; set; }
        /// <summary>
        /// Propiedad de navegacion de Envia
        /// </summary>
     
        public virtual Envia Envia { get; set; }
        public virtual ICollection<DetalleCotizacion> DetalleCotizacion { get; set; }
    }
}
