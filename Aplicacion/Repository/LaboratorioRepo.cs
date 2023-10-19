using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class LaboratorioRepo : GenericRepo<Laboratorios>, ILaboratorioRepo
{
     protected readonly VeterinariaContext _context;

    public LaboratorioRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Laboratorios>> GetAllAsync()
    {
        return await _context.Laboratorios

            .Include(p => p.Medicamentos)
            .ToListAsync();
    }

    public override async Task<Laboratorios> GetByIdAsync(int id)
    {
        return await _context.Laboratorios

        .Include(p => p.Medicamentos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}
