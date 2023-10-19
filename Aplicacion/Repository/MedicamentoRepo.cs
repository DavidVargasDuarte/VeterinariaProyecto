using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class MedicamentoRepo : GenericRepo<Medicamento>, IMedicamentoRepo
{
    protected readonly VeterinariaContext _context;

    public MedicamentoRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos

            .Include(p => p.Laboratorio)
            .Include(p => p.Proveedors)
            .Include(p => p.DetalleMovimientos)
            .Include(p => p.TratamientosMedics)
            .Include(p => p.MovimientoMedics)
            .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Medicamentos
            .Include(p => p.Laboratorio)
            .Include(p => p.Proveedors)
            .Include(p => p.DetalleMovimientos)
            .Include(p => p.TratamientosMedics)
            .Include(p => p.MovimientoMedics)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<object> MedicamentosGenfar()
    {
       return await _context.Medicamentos
        .Include(l => l.Laboratorio)
        .Where(l => l.Laboratorio.Nombre == "Genfar")
        .ToListAsync();
    }

    public async Task<object> PrecioMayorA50000()
    {
        var MayorA50 = await _context.Medicamentos
        .Where(m => m.Precio > 50000)
        .ToListAsync();

        return MayorA50;
    }
}
