using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using MCargoExpres.Api.Configuration;
using _3._1.MCargoExpress.Dtos;
using MediatR;
using _5._1.MCargoExpress.CRUD.Commands.Login;
using _5._1.MCargoExpress.CRUD.Commands._TipoPersona;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using _4.MCargoExpress.Aplication.Logic;
using _2._1.MCargoExpress.Persistence.Connection;
using _3._3.MCargoExpress.Interfaces;

namespace MCargoExpres.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();

            //Se configuran las conexiones de las base de datos
            ConnectionConfig.Config(Configuration, services);
            services.AddOptions();

            services.AddMediatR(typeof(Login.Manejador).Assembly);
            services.AddMediatR(typeof(_5._2.MCargoExpress.CRUD.Querys.Login.UsuarioActual).Assembly);
           
            //Configuracion del dapper
            DapperConfig.Config(Configuration, services);

            //Configura la seguridad del identity
            SeguridadConfig.Config(Configuration, services);

            //Configuracion del autoMapper
            services.AddAutoMapper(typeof(MappingProfiles));

            //Configuracion del swagger
            SwaggerConfig.Config(Configuration, services);

            //Configuracion de los cors
            CorsConfig.Config(Configuration, services);

            services.AddScoped<IContextos, Contextos>();
            services.AddScoped<ITipoPersonaService, TipoPersonaService>();
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configuracion del middleware
            MiddlewareConfig.Config(app);

            if (env.IsDevelopment())
            {
                // se deshabilita el uso de excepciones para usar el middleware
                //app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithReExecute("/errors", "?code={0}");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseCors("CorsRule");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaranathaCargoExpres-Api v1"));

        }
    }

    internal class AddTipoPersonaAsync
    {
    }
}
