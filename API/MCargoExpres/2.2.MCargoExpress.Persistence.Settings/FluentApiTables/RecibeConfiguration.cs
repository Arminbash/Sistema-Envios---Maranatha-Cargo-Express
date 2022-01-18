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
    /// Configuracion del modelo Recibe
    /// </summary>
    /// Francisco Rios
    public class RecibeConfiguration : IEntityTypeConfiguration<Recibe>
    {
        /// <summary>
        /// Configuracion del modelo
        /// </summary>
        /// <param name="builder">Configuracion de la entidad</param>
        /// Francisco Rios
        public void Configure(EntityTypeBuilder<Recibe> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.ClienteId)
                .IsRequired();
            builder
               .Property(b => b.Direccion)
               .IsRequired();
            builder
                .Property(b => b.Cuidad)
                .IsRequired();
            builder
               .Property(b => b.Estados)
               .IsRequired();
            builder
                .Property(b => b.CodigoPostal)
                .IsRequired();
            builder.Property(b => b.Estado).HasColumnType("bit");
        }
    }
}
