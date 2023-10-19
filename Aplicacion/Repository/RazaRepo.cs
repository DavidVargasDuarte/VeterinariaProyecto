using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class RazaRepo : GenericRepo<Razas>, IRazaRepo
{
    protected readonly VeterinariaContext _context;

        public RazaRepo(VeterinariaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Razas>> GetAllAsync()
        {
            return await _context.Razas

                .Include(p => p.Especie)
                .Include(p => p.Mascots)
                .ToListAsync();
        }

        public override async Task<Razas> GetByIdAsync(int id)
        {
            return await _context.Razas

                .Include(p => p.Especie)
                .Include(p => p.Mascots)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
}
