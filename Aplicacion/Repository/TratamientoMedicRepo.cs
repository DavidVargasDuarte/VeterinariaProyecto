using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class TratamientoMedicRepo : GenericRepo<TratamientosMedicos>, ITratamientoMedicRepo
{
    protected readonly VeterinariaContext _context;

    public TratamientoMedicRepo(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TratamientosMedicos>> GetAllAsync()
    {
        return await _context.TratamientosMedics

            .Include(p => p.Cita)
            .Include(p => p.Medicamento)
            .ToListAsync();
    }

    public override async Task<TratamientosMedicos> GetByIdAsync(int id)
    {
        return await _context.TratamientosMedics

            .Include(p => p.Cita)
            .Include(p => p.Medicamento)
        .FirstOrDefaultAsync(p => p.Id == id);
    }     
}
