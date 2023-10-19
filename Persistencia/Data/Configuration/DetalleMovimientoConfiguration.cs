using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
    {

        public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
        {
            builder.ToTable("DetalleMovimiento");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Cantidad)
            .IsRequired()
            .HasColumnName("Cantidad")
            .HasColumnType("int");

            builder.Property(f => f.Precio)
            .IsRequired()
            .HasColumnName("Precio")
            .HasColumnType("decimal");

            builder.HasOne(p => p.Medicamentos)
            .WithMany(p => p.DetalleMovimientos)
            .HasForeignKey(p => p.IdProductoFK);

            builder.HasOne(p => p.MovimientoMedics)
            .WithMany(p => p.DetalleMovimientos)
            .HasForeignKey(p => p.IdMovMedicFK);
        }
    }
}