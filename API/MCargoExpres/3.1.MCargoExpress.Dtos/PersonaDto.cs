using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{
   public class PersonaDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Primer Nombre
        /// </summary>
        public string PrimerNombre { get; set; }
        /// <summary>
        /// Segundo Nombre
        /// </summary>
        public string SegundoNombre { get; set; }
        /// <summary>
        /// Primer Apellido
        /// </summary>
        public string PrimerApellido { get; set; }
        ///<summary>
        /// Segundo apellido
        /// </summary>
        public string SegundoApellido { get; set; }
        ///<summary>
        /// Correo
        /// </summary>
        public string Correo { get; set; }
        ///<summary>
        /// Cedula
        /// </summary>
        public string Cedula { get; set; }

        ///<summary>
        /// Direccion
        /// </summary>
        public string Direccion { get; set; }
        ///<summary>
        /// Telefono
        /// </summary>
        public int Telefono { get; set; }
        ///<summary>
        /// codigo que identifica el tipo persona
        /// </summary>
        public int TipoPersonaId { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
