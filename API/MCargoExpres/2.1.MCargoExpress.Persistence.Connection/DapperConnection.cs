using _3._2.MCargoExpress.Enums;
using _3._3.MCargoExpress.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.MCargoExpress.Persistence.Connection
{
    /// <summary>
    /// Clase que se encarga de las conexiones de Dapper
    /// </summary>
    /// Johnny Arcia
    public class DapperConnection : IDapperConnection
    {
        private IDbConnection connection; //Conexion global Dapper
        private readonly IOptions<DapperConnectionConfig> configs; //Configuraciones de Conexiones
        /// <summary>
        /// Constructor de la clase con las configuraciones
        /// </summary>
        /// <param name="_configs">Configuraciones startup Dapper</param>
        /// Johnny Arcia
        public DapperConnection(IOptions<DapperConnectionConfig> _configs)
        {
            configs = _configs;
        }
        /// <summary>
        /// Metodo que cierra conexion con Dapper
        /// </summary>
        /// Johnny Arcia
        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Metodo que genera una conexion singleton de Dapper
        /// </summary>
        /// <returns>Conexions con la bd Dapper</returns>
        /// Johnny Arcia
        public IDbConnection GetConnection()
        {
            if (connection == null)
            {
                //Se evalua el tipo de Base de Datos y se configura su conexion
                string DB = Environment.GetEnvironmentVariable("Database");
                if(DB == Database.mySql) connection = new SqlConnection(configs.Value.mysqlConnection);
                if (DB == Database.sqlServer) connection = new SqlConnection(configs.Value.sqlServerConnection);
            }
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
