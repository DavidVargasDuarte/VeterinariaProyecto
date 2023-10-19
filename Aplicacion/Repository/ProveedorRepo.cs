using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class ProveedorRepo : GenericRepo<Proveedores>, IProveedorRepo
{
    protected readonly VeterinariaContext _context;

    public ProveedorRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Proveedores>> GetAllAsync()
    {
        return await _context.Proveedors

            .Include(p => p.Medicamentos)
            .Include(p => p.MedicamentoProveedors)
            .ToListAsync();
    }

    public override async Task<Proveedores> GetByIdAsync(int id)
    {
        return await _context.Proveedors
            .Include(p => p.Medicamentos)
            .Include(p => p.MedicamentoProveedors)
        .FirstOrDefaultAsync(p => p.Id == id);
    } 
}
