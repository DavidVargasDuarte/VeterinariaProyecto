using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class VeterinariaContext : DbContext
    {
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> Users { get; set; }
        public DbSet<Roles> Rols { get; set; }
        public DbSet<RolUsuarios> RolUsers { get; set; }
        public DbSet<Citas> Cits { get; set; }
        public DbSet<TratamientosMedicos> TratamientosMedics { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<MovimientoMedic> MovimientoMedics { get; set; }
        public DbSet<TipoMovimineto> TipoMoviminetos { get; set; }
        public DbSet<DetalleMovimiento> DetalleMovimientos { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Mascotas> Mascots { get; set; }
        public DbSet<Especies> Especie { get; set; }
        public DbSet<Razas> Razas { get; set; }
        public DbSet<Proveedores> Proveedors { get; set; }
        public DbSet<Laboratorios> Laboratorios { get; set; }
        public DbSet<MedicamentoProveedores> MedicamentoProveedors { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}