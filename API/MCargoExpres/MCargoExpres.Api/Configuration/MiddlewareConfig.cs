using _4.MCargoExpress.Aplication.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Configuration
{
    /// <summary>
    /// Clase estatica con las configuraciones del middleware
    /// </summary>
    /// Johnny Arcia
    public static class MiddlewareConfig
    {
        /// <summary>
        /// Metodo configuraciones del middeware en el startup
        /// </summary>
        /// <param name="app">interfaz con el builder de la aplicacion</param>
        /// Johnny Arcia
        public static void Config(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddleware>();
        }
    }
}
