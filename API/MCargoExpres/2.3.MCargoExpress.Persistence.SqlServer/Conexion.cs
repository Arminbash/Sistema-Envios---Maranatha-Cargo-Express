using System;
using _2._2.MCargoExpress.Persistence.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MCargoExpress.Persistence.SqlServer
{
    /// <summary>
    /// Clase contexto de la bd Sql server
    /// </summary>
    /// Johnny Arcia
    public class ConexionSqlServer : IDesignTimeDbContextFactory<IConexion>
    {
        /// <summary>
        /// Implementacion de patron contexto en tiempo de diseño
        /// </summary>
        /// <param name="args">Argumentos del diseño</param>
        /// <returns>Instancia de la clase IConexion con sql server</returns>
        /// Johnny Arcia
        public IConexion CreateDbContext(string[] args)
        {
            string ConnNameError = "";
            var connectionString = GetEnvironmentVariable("sqlServerConnection", ConnNameError);
            var optionsBuilder = new DbContextOptionsBuilder<IConexion>();
            optionsBuilder.UseSqlServer(connectionString);

            return new IConexion(optionsBuilder.Options);
        }

        /// <summary>
        /// Obtenemos las variables de entorno
        /// </summary>
        /// <param name="name">Nombre variable</param>
        /// <param name="errorMessage">Mensaje si ocurre un error</param>
        /// <returns>Retorna el valor de la variable</returns>
        /// <exception cref="Exception">Si resulta una excepcion entonces se guarda en la variable errorMessage</exception>
        /// Johnny Arcia
        private string GetEnvironmentVariable(string name, string errorMessage)
        {
            var connectionStringName = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new Exception(errorMessage);
            }
            return connectionStringName;
        }
    }
}