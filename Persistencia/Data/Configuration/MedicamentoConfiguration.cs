using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            builder.ToTable("Medicamento");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Nombre)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(f => f.CantidadDisponible)
            .IsRequired()
            .HasColumnName("CantidadDisponible")
            .HasColumnType("int");

            builder.Property(f => f.Precio)
            .IsRequired()
            .HasColumnName("Precio")
            .HasColumnType("decimal");

            builder.HasOne(p => p.Laboratorio)
            .WithMany(p => p.Medicamentos)
            .HasForeignKey(p => p.IdLaboratorioFK);
        }
    }
}