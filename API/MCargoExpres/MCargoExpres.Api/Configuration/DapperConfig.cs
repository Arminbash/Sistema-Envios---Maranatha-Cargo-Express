using _2._1.MCargoExpress.Persistence.Connection;
using _3._3.MCargoExpress.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Configuration
{
    /// <summary>
    /// Clase encargada de configurar Dapper en el Startup
    /// </summary>
    /// Johnny Arcia
    public static class DapperConfig
    {
        /// <summary>
        /// Metodos de configuracion
        /// </summary>
        /// <param name="Configuration">Configuracion del entorno</param>
        /// <param name="services">Servicios de registro Startup</param>
        /// Johnny Arcia
        public static void Config(IConfiguration Configuration, IServiceCollection services)
        {
            //Agregar el Dapper
            services.Configure<DapperConnectionConfig>(Configuration.GetSection("ConnectionStrings"));
            services.AddTransient<IDapperConnection, DapperConnection>();
        }
    }
}
