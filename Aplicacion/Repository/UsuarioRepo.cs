using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class UsuarioRepo : GenericRepo<Usuarios>, IUsuarioRepo
{
   protected readonly VeterinariaContext _context;

    public UsuarioRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Usuarios>> GetAllAsync()
    {
        return await _context.Users

            .Include(p => p.Rols)
            .Include(p => p.RolUsers)
            .ToListAsync();
    }

    public override async Task<Usuarios> GetByIdAsync(int id)
    {
        return await _context.Users

            .Include(p => p.Rols)
            .Include(p => p.RolUsers)

        .FirstOrDefaultAsync(p => p.Id == id);
    }      
}
