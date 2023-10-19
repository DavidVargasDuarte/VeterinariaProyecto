using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces;

public interface IMedicamentoRepo : IGenericRepo<Medicamento>
{
    Task<object> MedicamentosGenfar();
    Task<object> PrecioMayorA50000();
}
