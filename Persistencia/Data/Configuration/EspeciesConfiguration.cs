using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class EspeciesConfiguration : IEntityTypeConfiguration<Especies>
    {
        public void Configure(EntityTypeBuilder<Especies> builder)
        {
            builder.ToTable("Especies");

            builder.HasKey(e => e.Id
            );

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(50);
        }
    }
}