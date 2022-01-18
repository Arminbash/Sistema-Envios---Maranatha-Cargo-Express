using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces
{
    /// <summary>
    /// Almacena las conexiones del entorno
    /// </summary>
    /// Johnny Arcia
    public class DapperConnectionConfig
    {
        /// <summary>
        /// Conexion MySql
        /// </summary>
        public string mysqlConnection { get; set; }
        /// <summary>
        /// Conexion SqlServer
        /// </summary>
        public string sqlServerConnection { get; set; }
    }
}
