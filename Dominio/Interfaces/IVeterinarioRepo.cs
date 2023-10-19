using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IVeterinarioRepo : IGenericRepo<Veterinario>
    {
        Task<object> CirujanoVascular();
    }
}