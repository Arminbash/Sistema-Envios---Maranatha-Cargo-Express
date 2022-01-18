using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MCargoExpress.Domain
{ /// <summary>
  /// Modelo de configuraciones
  /// </summary>
  /// Francisco Rios
    public class Configuraciones:ClaseBase
    {
        
        /// <summary>
        /// Nombre Empresa
        /// </summary>
        public string NombreEmpresa { get; set; }
        ///<summary>
        /// Ruc
        /// </summary>
        public string Ruc { get; set; }
        ///<summary>
        /// Correo
        /// </summary>
        public string Correo { get; set; }
      
    }
}
