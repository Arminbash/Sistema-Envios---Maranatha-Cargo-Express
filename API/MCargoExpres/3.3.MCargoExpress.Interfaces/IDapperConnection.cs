using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces
{
    /// <summary>
    /// Interfaz de conexion Dapper
    /// </summary>
    /// Johnny Arcia
    public interface IDapperConnection
    {
        /// <summary>
        /// Implementacion cierre de conexion
        /// </summary>
        void CloseConnection();
        /// <summary>
        /// Implementacion obtener conexion
        /// </summary>
        /// <returns>Conexion Dapper</returns>
        IDbConnection GetConnection();
    }
}
