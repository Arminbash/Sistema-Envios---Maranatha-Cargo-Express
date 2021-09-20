using _2._2.MCargoExpress.Persistence.Settings;
using _3._2.MCargoExpress.Enums;
using MCargoExpress.Persistence.Mysql;
using MCargoExpress.Persistence.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MCargoExpres.Api
{
    /// <summary>
    /// Clase que se encarga de las conexiones a bases de datos segun la configuracion
    /// </summary>
    /// Johnny Arcia
    public static class ConnectionConfig
    {
        /// <summary>
        /// Metodo estatico que aplica las configuraciones del contexto
        /// </summary>
        /// <param name="Configuration">Interfaz de configuracion</param>
        /// <param name="services">Interfaz que registra los servicios</param>
        /// Johnny Arcia
        public static void Config(IConfiguration Configuration, IServiceCollection services)
        {
            //Se busca el tipo de base de datos configurada
            var db = Configuration.GetValue<string>("Database");
            //Configuracion Mysql
            if (db == Database.mySql)
            {
                //Se obtiene la ruta del contexto por medio de su NameSpace --MCargoExpress.Persistence.Mysql
                string assemblyName = typeof(ConexionMysql).Namespace;
                string mySqlConnectionStr = Configuration.GetConnectionString("mysqlConnection");
                services.AddDbContextPool<IConexion>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr),
                    //Se configura la ruta de migraciones por defecto en este conexto
                    optionsBuilder =>
                        optionsBuilder.MigrationsAssembly(assemblyName)
                        ));
            }
            //Configuracion SqlServer
            if (db == Database.sqlServer)
            {
                //Se obtiene la ruta del contexto por medio de su NameSpace --MCargoExpress.Persistence.SqlServer
                string assemblyName = typeof(ConexionSqlServer).Namespace;
                string sqlServerConnectionStr = Configuration.GetConnectionString("sqlServerConnection");
                services.AddDbContextPool<IConexion>(options => options.UseSqlServer(sqlServerConnectionStr,
                    //Se configura la ruta de migraciones por defecto en este conexto
                    optionsBuilder =>
                        optionsBuilder.MigrationsAssembly(assemblyName)
                    ));
            }
        }
    }
}