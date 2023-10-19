using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

public class MedicamentoProveedores 
{
    public int IdMedicamnetoFK { get; set; }
    public Medicamento Medicamentos { get; set; }
    public int IdProveedorFK { get; set; }
    public Proveedores Proveedor { get; set; }
}



