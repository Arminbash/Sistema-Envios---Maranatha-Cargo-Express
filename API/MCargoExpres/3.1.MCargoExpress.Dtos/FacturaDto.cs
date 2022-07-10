using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{

    /// <summary>
    /// Modelo de factura
    /// </summary>
    /// Eddy Vargas
    public class FacturaDto
    {
        /// <summary>
        /// Primary key
        /// </summary>

        public int Id { get; set; }

        /// <summary>
        /// clave foranea del Envia
        /// </summary>

        public int EnviaId { get; set; }
        public string Direccion { get; set; }
       
        public string Cuidad { get; set; }
       
        public string Estados { get; set; }
      
        public string CodigoPostal { get; set; }

        public int ClienteId { get; set; }
        /// <summary>
        /// clave foranea del Recibe
        /// </summary>
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


        public virtual ICollection<DetalleFacturaDto> DetalleFacturaDto { get; set; }
    }
}
