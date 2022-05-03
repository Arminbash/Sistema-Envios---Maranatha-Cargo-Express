using _2._2.MCargoExpress.Persistence.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            //Migracion de base datos cuando se ejecuta la api
            //await ApplyMigrations(webHost.Services);

            await webHost.RunAsync();
        }

        /// <summary>
        /// Aplica las migraciones pendientes cuando se ejecuta la api
        /// </summary>
        /// <param name="serviceProvider">Host proveedor de servicios</param>
        /// <returns>Tarea asincrona</returns>
        /// Johnny Arcia
        private static async Task ApplyMigrations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            await using IConexion dbContext = scope.ServiceProvider.GetRequiredService<IConexion>();

            await dbContext.Database.MigrateAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
