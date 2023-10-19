using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class EspeciesRepo : GenericRepo<Especies>, IEspecieRepo
{
    protected readonly VeterinariaContext _context;

    public EspeciesRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Especies>> GetAllAsync()
    {
        return await _context.Especie

            .Include(p => p.Razas)
            .Include(p => p.Mascotas)
            .ToListAsync();
    }

    public override async Task<Especies> GetByIdAsync(int id)
    {
        return await _context.Especie

        .Include(p => p.Razas)
        .Include(p => p.Mascotas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}

