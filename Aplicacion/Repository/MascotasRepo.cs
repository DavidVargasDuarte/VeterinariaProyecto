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
}
