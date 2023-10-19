using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class MovimientoMedicRepo : GenericRepo<MovimientoMedic>, IMovimientoMedicRepo
{
    protected readonly VeterinariaContext _context;

    public MovimientoMedicRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoMedic>> GetAllAsync()
    {
        return await _context.MovimientoMedics

            .Include(p => p.Medicamentos)
            .Include(p => p.TipoMovimientos)
            .Include(p => p.DetalleMovimientos)
            .ToListAsync();
    }

    public override async Task<MovimientoMedic> GetByIdAsync(int id)
    {
        return await _context.MovimientoMedics
            .Include(p => p.Medicamentos)
            .Include(p => p.TipoMovimientos)
            .Include(p => p.DetalleMovimientos)
        .FirstOrDefaultAsync(p => p.Id == id);
    } 
}
