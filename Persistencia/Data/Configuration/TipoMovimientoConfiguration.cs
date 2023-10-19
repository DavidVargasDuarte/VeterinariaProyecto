using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimineto>
    {
        public void Configure(EntityTypeBuilder<TipoMovimineto> builder)
        {
            builder.ToTable("TipoMovimineto");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Descripcion)
            .IsRequired()
            .HasColumnName("Descripcion")
            .HasColumnType("varchar")
            .HasMaxLength(150);
        }
    }
}