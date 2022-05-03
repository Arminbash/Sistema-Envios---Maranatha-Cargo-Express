using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos.Base
{
    /// <summary>
    /// Respuesta de un objeto paginado
    /// </summary>
    /// <typeparam name="T">Objeto que se pagino</typeparam>
    /// Johnny Arcia
    public class PaginationRequestBase <T> where T : class
    {
        public PaginationMetadataBase meta { get; set; }
        public List<T> data { get; set; }
    }
    /// <summary>
    /// Objeto con la informacion de la paginación
    /// </summary>
    /// Johnny Arcia
    public class PaginationMetadataBase
    {
        public int page { get; set; }
        public int pages { get; set; }
        public int perpage { get; set; }
        public int total { get; set; }
        public string sort { get; set; }
        public string field { get; set; }
    }
}
