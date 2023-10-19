using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class VeterinariosConfiguration : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            builder.ToTable("Veterinario");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(f => f.Correo)
            .IsRequired()
            .HasColumnName("Correo")
            .HasColumnType("varchar")
            .HasMaxLength(150);

            builder.Property(f => f.Telefono)
            .IsRequired()
            .HasColumnName("Telefono")
            .HasColumnType("varchar")
            .HasMaxLength(30);

            builder.Property(f => f.Especialidad)
            .IsRequired()
            .HasColumnName("Especialidad")
            .HasColumnType("varchar")
            .HasMaxLength(150);
        }
    }
}