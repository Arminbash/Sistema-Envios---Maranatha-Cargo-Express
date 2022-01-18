using _1.MCargoExpress.Domain;
using _2._2.MCargoExpress.Persistence.Settings.FluentApiTables;
using Microsoft.EntityFrameworkCore;

namespace _2._2.MCargoExpress.Persistence.Settings
{
    /// <summary>
    /// Clase que contiene todas las configuraciones del Fluent Api
    /// </summary>
    /// Johnny Arcia
    public class FluentApiBase
    {
        /// <summary>
        /// funcion que crea las configuraciones en el model builder
        /// </summary>
        /// <param name="modelBuilder">modelo de configuracion</param>
        /// Johnny Arcia
        public void Map(ref ModelBuilder modelBuilder)
        {
            new TraduccionConfiguration().Configure(modelBuilder.Entity<Traduccion>());
            new TraduccionConfiguration().Configure(modelBuilder.Entity<Traduccion>());
            new ClienteConfiguration().Configure(modelBuilder.Entity<Cliente>());
            new CotizacionConfiguration().Configure(modelBuilder.Entity<Cotizacion>());
            new DetalleCotizacionConfiguration().Configure(modelBuilder.Entity<DetalleCotizacion>());
            new DetalleFacturaConfiguration().Configure(modelBuilder.Entity<DetalleFactura>());
            new EmpleadoConfiguration().Configure(modelBuilder.Entity<Empleado>());
            new EmpresaConfiguration().Configure(modelBuilder.Entity<Configuraciones>());
            new EnviaConfiguration().Configure(modelBuilder.Entity<Envia>());
            new FacturaConfiguration().Configure(modelBuilder.Entity<Factura>());
            new PersonaConfiguration().Configure(modelBuilder.Entity<Persona>());
            new RecibeConfiguration().Configure(modelBuilder.Entity<Recibe>());
            new TipoClienteConfiguration().Configure(modelBuilder.Entity<TipoCliente>());
            new TipoPersonaConfiguration().Configure(modelBuilder.Entity<TipoPersona>());
        }
    }
}