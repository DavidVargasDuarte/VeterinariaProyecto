using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TartamientoMedicConfiguration : IEntityTypeConfiguration<TratamientosMedicos>
    {
        public void Configure(EntityTypeBuilder<TratamientosMedicos> builder)
        {
            builder.ToTable("TratamientosMedicos");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Id)
            .IsRequired()
            .HasMaxLength(3);

            builder.Property(f => f.Dosis)
            .IsRequired()
            .HasColumnName("Dosis")
            .HasColumnType("varchar")
            .HasMaxLength(150);

            builder.Property(f => f.FechaAdministracion)
            .IsRequired()
            .HasColumnName("FechaAdministracion")
            .HasColumnType("date");

            builder.Property(f => f.Observacion)
            .IsRequired()
            .HasColumnName("Observacion")
            .HasColumnType("varchar")
            .HasMaxLength(150);

            builder.HasOne(p => p.Cita)
            .WithMany(p => p.TratamientosMedicos)
            .HasForeignKey(p => p.Id);

            builder.HasOne(p => p.Medicamento)
            .WithMany(p => p.TratamientosMedics)
            .HasForeignKey(p => p.IdMedicamentoFK);
        }
    }
}