using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{
    /// <summary>
    /// Modelo de detalle de factura
    /// </summary>
    /// Eddy Vargas
    public class DetalleFacturaDto
    {

        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// clave foranea de la Factura
        /// </summary>

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

        public bool Estado { get; set; }

        

    }
}
