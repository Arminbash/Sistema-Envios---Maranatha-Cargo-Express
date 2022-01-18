using _4.MCargoExpress.Aplication.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MCargoExpress.Aplication.Middleware
{
    /// <summary>
    /// MiddleWare base de errores
    /// </summary>
    /// Johnny Arcia
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorMiddleware> logger;
        /// <summary>
        /// Contructor para injeccion de dependencias
        /// </summary>
        /// <param name="_next">Nuevo request</param>
        /// <param name="_logger">Manejador de errores</param>
        /// Johnny Arcia
        public ErrorMiddleware(RequestDelegate _next, ILogger<ErrorMiddleware> _logger)
        {
            next = _next;
            logger = _logger;
        }
        /// <summary>
        /// Metodo publico con el que se dispara la excepcion
        /// </summary>
        /// <param name="context">Contexto del status http</param>
        /// <returns>Retorna una tarea async</returns>
        /// Johnny Arcia
        public async Task Invoke(HttpContext context)
        {
            try
            {
                //Si la tarea se termina con exito, continua
                await next(context);
            }
            catch (Exception ex)
            {
                //Si ocurre un error se dispara una nueva tarea con el error del middleware
                await ManejadorExceptionAsincrono(context, ex, logger);
            }
        }
        /// <summary>
        /// Metodo encargado de generar y manejar las excepciones
        /// </summary>
        /// <param name="context">Contexto del status http</param>
        /// <param name="ex">Excepcion</param>
        /// <param name="logger">Manejador de errores</param>
        /// <returns>Nueva tarea con el error</returns>
        /// Johnny Arcia
        private async Task ManejadorExceptionAsincrono(HttpContext context, Exception ex, ILogger<ErrorMiddleware> logger)
        {
            object errores = null;
            //Se evalua el tipo de error
            switch (ex)
            {
               //Excepcion base controlada
                case ExceptionBase me:
                    logger.LogError(ex, "Manejador Error");
                    errores = me.errores;
                    context.Response.StatusCode = (int)me.codigo;
                    break;
                //Excepcion no controlada
                case Exception e:
                    logger.LogError(ex, "Error de servidor");
                    errores = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    break;
            }
            context.Response.ContentType = "application/json";
            if (errores != null)
            {
                var resultado = JsonConvert.SerializeObject(new { errores });
                //Se genera un nuevo proceso http
                await context.Response.WriteAsync(resultado);
            }

        }
    }
}
