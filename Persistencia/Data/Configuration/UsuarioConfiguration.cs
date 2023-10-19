using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
  public class UsuarioConfiguration : IEntityTypeConfiguration<Usuarios>
  {
    public void Configure(EntityTypeBuilder<Usuarios> builder)
    {
      builder.ToTable("Usuarios");

      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id)
      .HasMaxLength(3);

      builder.Property(p => p.NombrePersona)
      .IsRequired()
      .HasMaxLength(50);

      builder.Property(f => f.Correo)
      .IsRequired()
      .HasColumnName("Mail")
      .HasComment("Correo Usuario")
      .HasColumnType("varchar")
      .HasMaxLength(50);

      builder.Property(f => f.Contraseña)
      .IsRequired()
      .HasColumnName("Contraseña")
      .HasComment("Contraseña")
      .HasColumnType("Varchar")
      .HasMaxLength(15);

      builder.HasMany(p => p.Rols)
            .WithMany(r => r.Users)
            .UsingEntity<RolUsuarios>(
              j => j
                 .HasOne(pt => pt.Rol)
                 .WithMany(t => t.RolUsers)
                 .HasForeignKey(ut => ut.IdRolFK),

                 j => j
                 .HasOne(et => et.Usuario)
                 .WithMany(et => et.RolUsers)
                 .HasForeignKey(el => el.IdUserFK),

                 j =>
                 {
                   j.ToTable("RolUsuarios");
                   j.HasKey(t => new { t.IdUserFK, t.IdRolFK });
                 }
            );

    }
  }
}