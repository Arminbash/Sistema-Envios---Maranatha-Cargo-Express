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
    /// Configuracion del modelo Persona
    /// </summary>
    /// Francisco Rios
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        /// <summary>
        /// Configuracion del modelo
        /// </summary>
        /// <param name="builder">Configuracion de la entidad</param>
        /// Francisco Rios
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.PrimerNombre)
                .IsRequired();
            builder
               .Property(b => b.SegundoNombre)
               .IsRequired();
            builder
                .Property(b => b.PrimerApellido)
                .IsRequired();
            builder
               .Property(b => b.SegundoApellido)
               .IsRequired();
            builder
                .Property(b => b.Correo)
                .IsRequired();
            builder
               .Property(b => b.Cedula)
               .IsRequired();
            builder
                .Property(b => b.Direccion)
                .IsRequired();
            builder
               .Property(b => b.Telefono)
               .IsRequired();
            builder
               .Property(b => b.TipoPersonaId)
               .IsRequired();
            builder.Property(b => b.Estado).HasColumnType("bit");
        }
    }
}
