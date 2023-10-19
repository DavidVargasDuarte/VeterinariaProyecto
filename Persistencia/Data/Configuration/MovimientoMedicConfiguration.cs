using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MovimientoMedicConfiguration : IEntityTypeConfiguration<MovimientoMedic>
    {
        public void Configure(EntityTypeBuilder<MovimientoMedic> builder)
        {
            builder.ToTable("MovimientoMedic");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Cantidad)
            .IsRequired()
            .HasColumnName("Cantidad")
            .HasColumnType("int");

            builder.Property(f => f.Fecha)
            .IsRequired()
            .HasColumnName("Fecha")
            .HasColumnType("date");

            builder.HasOne(p => p.Medicamentos)
            .WithMany(p => p.MovimientoMedics)
            .HasForeignKey(p => p.IdProductoFK);

            builder.HasOne(p => p.TipoMovimientos)
            .WithMany(p => p.MovimientoMedics)
            .HasForeignKey(p => p.IdTipoMovimientoFK);
        }
    }
}