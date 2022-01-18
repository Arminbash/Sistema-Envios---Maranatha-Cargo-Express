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
    public class Cliente:ClaseBase
    {
        /// <summary>
        /// clave forena de persona
        /// </summary>
        [ForeignKey("Persona")]
        public int PersonaId { get; set; }
        /// <summary>
        /// Tipo de Cliente
        /// </summary>
        [ForeignKey("TipoCliente")]
        public int TipoClienteId { get; set; }
        
        /// <summary>
        /// Propiedad de navegacion de persona
        /// </summary>
        public virtual Persona Persona { get; set; }
        /// <summary>
        /// Propiedad de navegacion del tipo cliente
        /// </summary>
        public virtual TipoCliente TipoCliente { get; set; }
        public virtual ICollection<Envia> Envia { get; set; }
        public virtual ICollection<Recibe> Recibe { get; set; }

    }
}
