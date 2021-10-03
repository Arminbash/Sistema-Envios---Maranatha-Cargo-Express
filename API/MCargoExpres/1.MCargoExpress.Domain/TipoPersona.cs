using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MCargoExpress.Domain
{
   
        /// <summary>
        /// Modelo de persona
        /// </summary>
        /// Francisco Rios
        public class TipoPersona : ClaseBase
        {

            /// <summary>
            /// Tipo de Persona
            /// </summary>
            public string Tipo { get; set; }

            /// <summary>
            /// clave forranea del  persona
            /// </summary>
            public virtual ICollection<Persona> Persona { get; set; }
        }
    }

