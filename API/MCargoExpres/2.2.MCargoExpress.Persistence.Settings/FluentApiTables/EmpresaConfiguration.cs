using _1.MCargoExpress.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2._2.MCargoExpress.Persistence.Settings.FluentApiTables
{

    // <summary>
    /// Configuracion del modelo Empresa
    /// </summary>
    /// Francisco Rios
    public class EmpresaConfiguration : IEntityTypeConfiguration<Configuraciones>
    {


        /// <summary>
        /// Configuracion del modelo
        /// </summary>
        /// <param name="builder">Configuracion de la entidad</param>
        /// Francisco Rios
        public void Configure(EntityTypeBuilder<Configuraciones> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.NombreEmpresa)
                .IsRequired();
            builder
               .Property(b => b.Ruc)
               .IsRequired();
            builder
              .Property(b => b.Correo)
              .IsRequired();
            builder.Property(b => b.Estado).HasColumnType("bit");
        }
    }
}
