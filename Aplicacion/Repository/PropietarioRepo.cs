using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PropietarioRepo : GenericRepo<Propietario>, IPropietarioRepo
{
    protected readonly VeterinariaContext _context;

    public PropietarioRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _context.Propietarios

            .Include(p => p.Mascots)
            .ToListAsync();
    }

    public override async Task<Propietario> GetByIdAsync(int id)
    {
        return await _context.Propietarios
            .Include(p => p.Mascots)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public static implicit operator PropietarioRepo(ProveedorRepo v)
    {
        throw new NotImplementedException();
    }
}
