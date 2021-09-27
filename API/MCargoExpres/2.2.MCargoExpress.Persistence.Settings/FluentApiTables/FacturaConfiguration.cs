using _1.MCargoExpress.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2.MCargoExpress.Persistence.Settings.FluentApiTables
{
    /// <summary>
    /// Configuracion del modelo Factura
    /// </summary>
    /// Francisco Rios
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        /// <summary>
        /// Configuracion del modelo
        /// </summary>
        /// <param name="builder">Configuracion de la entidad</param>
        /// Francisco Rios
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.EnviaId)
                .IsRequired();
            builder
               .Property(b => b.RecibeId)
               .IsRequired();
            builder
                .Property(b => b.FechaIngreso)
                .IsRequired();
            builder
               .Property(b => b.TipoMoneda)
               .IsRequired();
            builder
                .Property(b => b.TipoPago)
                .IsRequired();
            builder
              .Property(b => b.Observacion)
              .IsRequired();
            builder
                .Property(b => b.TasaCambio)
                .IsRequired();
            builder.Property(b => b.Estado).HasColumnType("bit");
        }
    }
}
