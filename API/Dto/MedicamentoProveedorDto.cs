using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class MedicamentoProveedorDto 
    {
        public int IdMedicamnetoFK { get; set; }
        public int IdProveedorFK { get; set; }
    }
}