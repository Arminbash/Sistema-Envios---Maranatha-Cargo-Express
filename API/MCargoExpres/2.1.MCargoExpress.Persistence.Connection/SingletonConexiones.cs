using _3._3.MCargoExpress.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.MCargoExpress.Persistence.Connection
{
    /// <summary>
    /// Clase singleton que contiene las configuraciones globales de las conexiones
    /// </summary>
    /// Johnny Arcia
    public static class SingletonConexiones
    {
        /// <summary>
        /// Conexion principal de la base de datos MCE
        /// </summary>
        public static DbContextOptionsBuilder optionsConexion;
        /// <summary>
        /// Conexion con la base de datos MCE
        /// </summary>
        public static string ConnectionString;
    }
}
