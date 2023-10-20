using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces;

public interface IMascotaRepo : IGenericRepo<Mascotas>
{
    Task<object> EspecieFelina();
    Task<object> RazasCantidadMascotas();
    Task<IEnumerable<Mascotas>> MascotasVacunadas2023();
    Task<object> MascotaEspecie();
    Task<object> MascotaXVeterinario();
}
