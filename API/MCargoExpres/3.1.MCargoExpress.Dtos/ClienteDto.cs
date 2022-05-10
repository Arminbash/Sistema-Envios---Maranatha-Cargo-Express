using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{
   public class ClienteDto
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// clave forena de persona
        /// </summary>
        public int PersonaId { get; set; }
        public string PrimerNombre { get; set; }
        /// <summary>
        /// Tipo de Cliente
        /// </summary>
        public int TipoClienteId { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
