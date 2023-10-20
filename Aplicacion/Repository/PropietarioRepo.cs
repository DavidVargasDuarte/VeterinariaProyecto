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

    public async Task<object> GoldenRetriever()
    {
        var consulta = from p in _context.Propietarios
                       select new
                       {
                           nombre = p.Nombre,
                           email = p.Correo,
                           telefono = p.Telefono,
                           mascotas = (from m in _context.Mascots
                                       join r in _context.Razas on m.IdRazaFK equals r.Id
                                       where r.Nombre == "Golden Retriver"
                                       where m.IdPropietarioFK == p.Id
                                       select new
                                       {
                                           Nombre = m.Nombre,
                                           FechaNacimiento = m.FechaNacimiento,
                                           Raza = r.Nombre
                                       }).ToList()
                       };

        var goldenRetriever = await consulta.ToListAsync();
        return goldenRetriever;
    }
}
