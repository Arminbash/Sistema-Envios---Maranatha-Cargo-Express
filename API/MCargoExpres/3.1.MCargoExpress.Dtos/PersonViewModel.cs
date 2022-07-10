using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{
    public class PersonViewModel
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Primer Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Correo
        /// </summary>
        public string Correo { get; set; }
        ///<summary>
        /// Cedula
        /// </summary>
        public string Cedula { get; set; }

        ///<summary>
        /// Telefono
        /// </summary>
        public int Telefono { get; set; }
        ///<summary>
        /// codigo que identifica el tipo persona
        /// </summary>
        public string TipoPersona { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
