using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ProveedoresConfiguration : IEntityTypeConfiguration<Proveedores>
    {
        public void Configure(EntityTypeBuilder<Proveedores> builder)
        {
            builder.ToTable("Proveedores");

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

            builder.Property(f => f.Direccion)
            .IsRequired()
            .HasColumnName("Direccion")
            .HasComment("Direccion Usuario")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(f => f.Telefono)
            .IsRequired()
            .HasColumnName("Telefono")
            .HasComment("Telefono")
            .HasColumnType("varchar")
            .HasMaxLength(10);

            builder.HasMany(p => p.Medicamentos)
               .WithMany(r => r.Proveedors)
               .UsingEntity<MedicamentoProveedores>(

                   j => j
                   .HasOne(pt => pt.Medicamentos)
                   .WithMany(t => t.MedicamentoProveedors)
                   .HasForeignKey(ut => ut.IdMedicamnetoFK),

                   j => j
                   .HasOne(et => et.Proveedor)
                   .WithMany(et => et.MedicamentoProveedors)
                   .HasForeignKey(el => el.IdProveedorFK),

                   j =>
                   {
                       j.ToTable("MedicamentoProveedores");
                       j.HasKey(t => new { t.IdProveedorFK, t.IdMedicamnetoFK });

                   });
        }
    }
}