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
    /// Configuracion del modelo DetalleFactura
    /// </summary>
    /// Francisco Rios
    class DetalleFacturaConfiguration : IEntityTypeConfiguration<DetalleFactura>
    {
        /// <summary>
        /// Configuracion del modelo
        /// </summary>
        /// <param name="builder">Configuracion de la entidad</param>
        /// Francisco Rios
        public void Configure(EntityTypeBuilder<DetalleFactura> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.FacturaId)
                .IsRequired();
            builder
               .Property(b => b.Descripcion)
               .IsRequired();
            builder
                .Property(b => b.Rate)
                .IsRequired();
            builder
               .Property(b => b.LBS)
               .IsRequired();
            builder
                .Property(b => b.VOL)
                .IsRequired();
            builder
               .Property(b => b.IVA)
               .IsRequired();
            builder.Property(b => b.Estado).HasColumnType("bit");
        }
    }
}
