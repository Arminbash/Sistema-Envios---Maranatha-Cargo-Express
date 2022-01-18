using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{
    /// <summary>
    /// Dto para el modelo traduccion
    /// </summary>
    /// Johnny Arcia
    public class TraduccionDto 
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// codigo clave que identifica la traduccion
        /// </summary>
        public string Llave { get; set; }
        /// <summary>
        /// Valor de la clave
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
        /// Lenguaje del valor
        /// </summary>
        public string Lang { get; set; }
        /// <summary>
        /// Tipo de clave
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
