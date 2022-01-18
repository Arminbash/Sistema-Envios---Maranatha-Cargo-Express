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
    public class Persona : ClaseBase
    {
        
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
        [ForeignKey("TipoPersona")]
        public int TipoPersonaId { get; set; }
        ///<summary>
        /// propiedad de navegacion de tipo persona
        /// </summary>
        public virtual TipoPersona TipoPersona { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}

