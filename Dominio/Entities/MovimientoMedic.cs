using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio;

public class MovimientoMedic : BaseEntity
{
  
    public int IdProductoFK { get; set; }
    public Medicamento Medicamentos { get; set; }
    public int Cantidad { get; set; }
    public DateOnly Fecha { get; set; }
    public int IdTipoMovimientoFK { get; set; }
    public TipoMovimineto TipoMovimientos { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
}
