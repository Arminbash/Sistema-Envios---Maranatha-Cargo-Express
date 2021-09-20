using _1.MCargoExpress.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2._2.MCargoExpress.Persistence.Settings.FluentApiTables
{
    /// <summary>
    /// Configuracion del modelo traduccion
    /// </summary>
    /// Johnny Arcia
    public class TraduccionConfiguration : IEntityTypeConfiguration<Traduccion>
    {
        /// <summary>
        /// Configuracion del modelo
        /// </summary>
        /// <param name="builder">Configuracionde la entidad</param>
        /// Johnny Arcia
        public void Configure(EntityTypeBuilder<Traduccion> builder)
        {
            builder.HasKey(b =>b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.Llave)
                .IsRequired();
            builder.Property(b => b.Estado).HasColumnType("bit");
        }
    }
}