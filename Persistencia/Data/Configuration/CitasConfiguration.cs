using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CitasConfiguration : IEntityTypeConfiguration<Citas>
    {
        public void Configure(EntityTypeBuilder<Citas> builder)
        {
            builder.ToTable("Cita");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Fecha)
            .IsRequired()
            .HasColumnName("Fecha")
            .HasColumnType("date");

            builder.Property(f => f.Hora)
            .IsRequired()
            .HasColumnName("Hora")
            .HasColumnType("time");

            builder.Property(f => f.Motivo)
            .IsRequired()
            .HasColumnName("Motivo")
            .HasColumnType("varchar")
            .HasMaxLength(150);

            builder.HasOne(p => p.Mascota)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.IdMascota);

            builder.HasOne(p => p.Veterinarios)
            .WithMany(p => p.Cits)
            .HasForeignKey(p => p.IdVeterinariaFK);
        }
    }
}