using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MascotasConfiguration : IEntityTypeConfiguration<Mascotas>
    {
        public void Configure(EntityTypeBuilder<Mascotas> builder)
        {
            builder.ToTable("Mascotas");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(f => f.FechaNacimiento)
            .IsRequired()
            .HasColumnName("FechaNacimiento")
            .HasColumnType("date");

            builder.HasOne(p => p.Propietarios)
            .WithMany(p => p.Mascots)
            .HasForeignKey(p => p.IdPropietarioFK);

            builder.HasOne(p => p.Especie)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.IdEspecieFK);

            builder.HasOne(p => p.Raza)
            .WithMany(p => p.Mascots)
            .HasForeignKey(p => p.IdRazaFK);
        }
    }
}