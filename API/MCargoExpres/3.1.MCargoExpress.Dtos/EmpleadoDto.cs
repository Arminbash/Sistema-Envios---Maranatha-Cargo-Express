using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{
  public class EmpleadoDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// clave forrane de persona
        /// </summary>
        public int PersonaId { get; set; }
        /// <summary>
        /// Fecha ingreso
        /// </summary>
        public DateTime? FechaIngreso { get; set; }
        /// <summary>
        /// nombre del cargo
        /// </summary>
        public string Cargo { get; set; }
        ///<summary>
        /// Numero de licencia
        /// </summary>
        public string NumeroLicencia { get; set; }
        ///<summary>
        /// Foto
        /// </summary>
        public byte Foto { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }

    }
}
