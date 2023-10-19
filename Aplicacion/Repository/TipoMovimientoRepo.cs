using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class TipoMovimientoRepo : GenericRepo<TipoMovimineto>, ITipoMovimientoRepo
{
    protected readonly VeterinariaContext _context;

    public TipoMovimientoRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoMovimineto>> GetAllAsync()
    {
        return await _context.TipoMoviminetos

            .Include(p => p.MovimientoMedics)
            .ToListAsync();
    }

    public override async Task<TipoMovimineto> GetByIdAsync(int id)
    {
        return await _context.TipoMoviminetos

            .Include(p => p.MovimientoMedics)
        .FirstOrDefaultAsync(p => p.Id == id);
    } 
}
