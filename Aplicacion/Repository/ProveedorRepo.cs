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

    public async Task<object> ProveedorMedicamentos()
    {
        var proveedorMedicamento = from m in _context.Medicamentos
                                   select new
                                   {
                                       nombre = m.Nombre,
                                       proveedores = (from mp in _context.MedicamentoProveedors
                                                      join me in _context.Medicamentos on mp.IdMedicamnetoFK equals me.Id
                                                      join p in _context.Proveedors on mp.IdProveedorFK equals p.Id
                                                      where m.Id == mp.IdMedicamnetoFK
                                                      select new
                                                      {
                                                          nombre = p.Nombre,
                                                      }).ToList()
                                   };

        var medicamentoxProveedor = await proveedorMedicamento.ToListAsync();
        return medicamentoxProveedor;
    }
}
