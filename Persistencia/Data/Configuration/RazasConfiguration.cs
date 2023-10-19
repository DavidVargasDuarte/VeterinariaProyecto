using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RazasConfiguration : IEntityTypeConfiguration<Razas>
    {
        public void Configure(EntityTypeBuilder<Razas> builder)
        {
            builder.ToTable("Raza");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.HasOne(p => p.Especie)
            .WithMany(p => p.Razas)
            .HasForeignKey(p => p.IdEspecieFK);
        }
    }
}