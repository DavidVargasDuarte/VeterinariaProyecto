using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class CitaRepo : GenericRepo<Citas>, ICitaRepo
{

    protected readonly VeterinariaContext _context;

    public CitaRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Citas>> GetAllAsync()
    {
        return await _context.Cits
            .Include(p => p.Mascota)
            .Include(p => p.Veterinarios)
            .ToListAsync();
    }

    public override async Task<Citas> GetByIdAsync(int id)
    {
        return await _context.Cits
        .Include(p => p.Mascota)
        .Include(p => p.Veterinarios)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
