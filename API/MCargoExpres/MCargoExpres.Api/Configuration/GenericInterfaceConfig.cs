using _2._1.MCargoExpress.Persistence.Connection;
using _3._3.MCargoExpress.Interfaces;
using _4.MCargoExpress.Aplication.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Configuration
{
    /// <summary>
    /// Clase que se encarga de las conexiones a bases de datos segun la configuracion
    /// </summary>
    /// Johnny Arcia
    public static class GenericInterfaceConfig
    {
        /// <summary>
        /// Metodo estatico que aplica las configuraciones del contexto
        /// </summary>
        /// <param name="Configuration">Interfaz de configuracion</param>
        /// <param name="services">Interfaz que registra los servicios</param>
        /// Johnny Arcia
        public static void Config(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
