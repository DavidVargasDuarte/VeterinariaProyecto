using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class MascotasRepo : GenericRepo<Mascotas>, IMascotaRepo
{
    protected readonly VeterinariaContext _context;

    public MascotasRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Mascotas>> GetAllAsync()
    {
        return await _context.Mascots

            .Include(p => p.Propietarios)
            .Include(p => p.Especie)
            .Include(p => p.Raza)
            .Include(p => p.Citas)
            .ToListAsync();
    }

    public override async Task<Mascotas> GetByIdAsync(int id)
    {
        return await _context.Mascots
            .Include(p => p.Propietarios)
            .Include(p => p.Especie)
            .Include(p => p.Raza)
            .Include(p => p.Citas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public virtual async Task<object> EspecieFelina()
    {
        var Felinos = await (
            from m in _context.Mascots
            join r in _context.Razas on m.IdRazaFK equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFK equals p.Id
            join e in _context.Especie on r.IdEspecieFK equals e.Id
            where e.Nombre.Contains("Felina")
            select new
            {
                Nombres = m.Nombre,
                Propietario = p.Nombre,
                FechaDeNacimiento = m.FechaNacimiento
            }
        ).Distinct()
        .ToListAsync();

        return Felinos;
    }

    public async Task<object> RazasCantidadMascotas()
    {
        var cantidadRazas =
        from r in _context.Razas
        select new
        {
            nombre = r.Nombre,
            cantidad = _context.Mascots.Distinct().Count(m => m.IdRazaFK == r.Id)
        };

        var mascotasPorRaza = await cantidadRazas.ToListAsync();
        return mascotasPorRaza;
    }

    public async Task<IEnumerable<Mascotas>> MascotasVacunadas2023()
    {
        DateOnly inicioTrimestre = new DateOnly(2023, 1, 1);
        DateOnly finTrimestre = new DateOnly(2023, 3, 31);

        var mascotasVacunacion = await _context.Cits
            .Where(c => c.Fecha >= inicioTrimestre && c.Fecha <= finTrimestre && c.Motivo == "Vacunacion")
            .Select(c => c.Mascota)
            .Distinct()
            .ToListAsync();

        return mascotasVacunacion;
    }

    public async Task<object> MascotaEspecie()
    {
        var mascotaEspecie =
        from e in _context.Especie
        select new
        {
            nombre = e.Nombre,
            mascotas = (from m in _context.Mascots
                        join r in _context.Razas on m.IdRazaFK equals r.Id
                        where m.IdRazaFK == r.Id
                        where r.IdEspecieFK == e.Id
                        select new
                        {
                            Nombre = m.Nombre,
                            FechaNacimiento = m.FechaNacimiento,
                            Raza = r.Nombre
                        }).ToList()
        };

        var especiesMascota = await mascotaEspecie.ToListAsync();
        return especiesMascota;
    }

    public async Task<object> MascotaXVeterinario()
    {
        var mascotasAtendidas =
        from e in _context.Cits
        join v in _context.Veterinarios on e.IdVeterinariaFK equals v.Id
        select new
        {
            veterinario = v.Nombre,
            mascotas = (from c in _context.Cits
                        join m in _context.Mascots on c.IdMascota equals m.Id
                        where c.IdVeterinariaFK == v.Id
                        select new
                        {
                            Nombre = m.Nombre,
                            FechaNacimiento = m.FechaNacimiento,
                        }).ToList()
        };

        var atendidas = await mascotasAtendidas.ToListAsync();
        return atendidas;
    }
}
