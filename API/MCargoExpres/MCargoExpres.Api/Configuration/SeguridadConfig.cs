using _1.MCargoExpress.Domain;
using _3._3.MCargoExpress.Interfaces.Security;
using _4.MCargoExpress.Aplication.Security;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2._2.MCargoExpress.Persistence.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MCargoExpres.Api.Configuration
{
    /// <summary>
    /// Clase que se encarga de configurar las seguridad en el startup
    /// </summary>
    /// Johnny Arcia
    public class SeguridadConfig
    {
        /// <summary>
        /// Metodo estatico que aplica las de seguridad del identity
        /// </summary>
        /// <param name="Configuration">Interfaz de configuracion</param>
        /// <param name="services">Interfaz que registra los servicios</param>
        /// Johnny Arcia
        public static void Config(IConfiguration Configuration, IServiceCollection services)
        {
            //Configuracion IdentityCore
            var builder = services.AddIdentityCore<Usuario>(options => 
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
            });
            var IdentityBuilder = new IdentityBuilder(builder.UserType, builder.Services);

            //Agregar seguridad Roles
            IdentityBuilder.AddRoles<IdentityRole>();
            IdentityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Usuario, IdentityRole>>();

            //Validaciones opcionales del password
            IdentityBuilder.AddPasswordValidator<_4.MCargoExpress.Aplication.Security.PasswordValidator<Usuario>>();

            //instanciar entity
            IdentityBuilder.AddEntityFrameworkStores<IConexion>();
            IdentityBuilder.AddSignInManager<SignInManager<Usuario>>();

            services.TryAddSingleton<ISystemClock, SystemClock>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Key para los tokens del identity"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });

            // Inyectar Jwtoken
            services.AddScoped<IJwtGenerador, JwtHelper>();

            // Para retornar el usuario log
            services.AddScoped<IUsuarioHelper, UsuarioHelper>();

        }
    }
}
