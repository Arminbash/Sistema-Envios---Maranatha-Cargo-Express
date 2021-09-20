using _1.MCargoExpress.Domain;
using _2._2.MCargoExpress.Persistence.Settings.FluentApiTables;
using Microsoft.EntityFrameworkCore;

namespace _2._2.MCargoExpress.Persistence.Settings
{
    /// <summary>
    /// Clase que contiene todas las configuraciones del Fluent Api
    /// </summary>
    /// Johnny Arcia
    public class FluentApiBase
    {
        /// <summary>
        /// funcion que crea las configuraciones en el model builder
        /// </summary>
        /// <param name="modelBuilder">modelo de configuracion</param>
        /// Johnny Arcia
        public void Map(ref ModelBuilder modelBuilder)
        {
            new TraduccionConfiguration().Configure(modelBuilder.Entity<Traduccion>());
        }
    }
}