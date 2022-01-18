﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCargoExpres.Api.Configuration
{
    /// <summary>
    /// Clase que se encarga de configurar el swagger
    /// </summary>
    /// Johnny Arcia
    public class SwaggerConfig
    {
        /// <summary>
        /// Metodo estatico que aplica las configuraciones del swagger
        /// </summary>
        /// <param name="Configuration">Interfaz de configuracion</param>
        /// <param name="services">Interfaz que registra los servicios</param>
        /// Johnny Arcia
        public static void Config(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MaranathaCargoExpres-Api",
                    Version = "v1"
                }

                );

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

                c.CustomSchemaIds(c => c.FullName);
            });
        }
    }
}
