using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class RolesRepo : GenericRepo<Roles>, IRolesRepo
{
    protected readonly VeterinariaContext _context;

    public RolesRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Roles>> GetAllAsync()
    {
        return await _context.Rols

            .Include(p => p.Users)
            .Include(p => p.RolUsers)
            .ToListAsync();
    }

    public override async Task<Roles> GetByIdAsync(int id)
    {
        return await _context.Rols

            .Include(p => p.Users)
            .Include(p => p.RolUsers)
        .FirstOrDefaultAsync(p => p.Id == id);
    } 
}
