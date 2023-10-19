using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class LaboratoriosConfiguration : IEntityTypeConfiguration<Laboratorios>
    {
        public void Configure(EntityTypeBuilder<Laboratorios> builder)
        {
            builder.ToTable("Laboratorios");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(50);

             builder.Property(f => f.Direccion)
            .IsRequired()
            .HasColumnName("Direccion")
            .HasColumnType("varchar")
            .HasMaxLength(50);

             builder.Property(f => f.Telefono)
            .IsRequired()
            .HasColumnName("Telefono")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            
        }
    }
}