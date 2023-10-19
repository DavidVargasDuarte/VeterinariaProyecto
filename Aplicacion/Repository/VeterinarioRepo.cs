using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class VeterinarioRepo : GenericRepo<Veterinario>, IVeterinarioRepo
{
    protected readonly VeterinariaContext _context;

    public VeterinarioRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<object> CirujanoVascular()
    {
        return await _context.Veterinarios
            .Where(p =>p.Especialidad == "Cirujano Vascular")
            .ToListAsync();
    }

    public override async Task<IEnumerable<Veterinario>> GetAllAsync()
    {
        return await _context.Veterinarios

            .Include(p => p.Cits)
            .ToListAsync();
    }

    public override async Task<Veterinario> GetByIdAsync(int id)
    {
        return await _context.Veterinarios

            .Include(p => p.Cits)


        .FirstOrDefaultAsync(p => p.Id == id);
    }

   



   
}
