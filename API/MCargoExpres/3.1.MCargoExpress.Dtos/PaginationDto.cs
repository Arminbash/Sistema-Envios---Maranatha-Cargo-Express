using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.MCargoExpress.Dtos
{
    /// <summary>
    /// Dto para manejar la paginacion en los elementos
    /// </summary>
    /// Johnny Arcia
    public class PaginationDto : SortDto
    {
        public int page { get; set; }
        public int pages { get; set; }
        public int perpage { get; set; }
        public int total { get; set; }
    }
    /// <summary>
    /// Manejo de ordenamiento
    /// </summary>
    public class SortDto : QueryDto
    {
        public string sort { get; set; }
        public string field { get; set; }
    }
    /// <summary>
    /// Dto con el objeto de consultas
    /// </summary>
    public class QueryDto 
    { 
        public bool? Estado { get; set; }
        public string generalSearch { get; set; }
    }
}
