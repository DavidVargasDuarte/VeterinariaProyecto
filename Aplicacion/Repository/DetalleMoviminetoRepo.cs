using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DetalleMoviminetoRepo : GenericRepo<DetalleMovimiento>, IDetalleMovimientoRepo
{
    protected readonly VeterinariaContext _context;

    public DetalleMoviminetoRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleMovimiento>> GetAllAsync()
    {
        return await _context.DetalleMovimientos

            .Include(p => p.Medicamentos)
            .Include(p => p.MovimientoMedics)
            .ToListAsync();
    }

    public override async Task<DetalleMovimiento> GetByIdAsync(int id)
    {
        return await _context.DetalleMovimientos

        .Include(p => p.Medicamentos)
        .Include(p => p.MovimientoMedics)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
