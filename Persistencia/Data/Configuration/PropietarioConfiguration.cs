using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>
    {
        public void Configure(EntityTypeBuilder<Propietario> builder)
        {
            builder.ToTable("Propietario");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasComment("Nombre Usuario")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(f => f.Correo)
            .IsRequired()
            .HasColumnName("Mail")
            .HasComment("Correo Usuario")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(f => f.Telefono)
            .IsRequired()
            .HasColumnName("Telefono")
            .HasComment("Telefono")
            .HasColumnType("varchar")
            .HasMaxLength(10);

            


        }
    }
}